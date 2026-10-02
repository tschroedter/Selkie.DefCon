using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NSubstitute;

namespace Selkie.DefCon.One.Arguments
{
    public class ObjectFactory : IObjectFactory
    {
        private readonly ConcurrentDictionary<Type, object> _frozen = new();
        private readonly ConcurrentDictionary<Type, bool> _nullTypes = new();

        public object Create(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (_nullTypes.ContainsKey(type))
                return null;

            if (_frozen.TryGetValue(type, out var frozen))
                return frozen;

            // Handle Lazy<T>
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Lazy<>))
            {
                var inner = type.GenericTypeArguments[0];

                var funcType = typeof(Func<>).MakeGenericType(inner);

                var callExpr = Expression.Call(Expression.Constant(this),
                                               typeof(ObjectFactory).GetMethod(nameof(Create), new[] { typeof(Type) }),
                                               Expression.Constant(inner));

                var converted = Expression.Convert(callExpr, inner);

                var lambda = Expression.Lambda(funcType, converted);

                var del = lambda.Compile();

                var lazyType = typeof(Lazy<>).MakeGenericType(inner);
                return Activator.CreateInstance(lazyType, del);
            }

            // Interfaces and abstract types -> NSubstitute
            if (type.IsInterface || type.IsAbstract)
            {
                var substitute = Substitute.For(new[] { type }, Array.Empty<object>());
                return substitute;
            }

            // Delegates -> create a delegate that returns created value for return type
            if (typeof(Delegate).IsAssignableFrom(type))
            {
                var invoke = type.GetMethod("Invoke");
                var returnType = invoke.ReturnType;

                var parameters = invoke.GetParameters().Select(p => Expression.Parameter(p.ParameterType, p.Name)).ToArray();

                Expression body;

                if (returnType == typeof(void))
                {
                    body = Expression.Empty();
                }
                else
                {
                    var callExpr = Expression.Call(Expression.Constant(this),
                                                   typeof(ObjectFactory).GetMethod(nameof(Create), new[] { typeof(Type) }),
                                                   Expression.Constant(returnType));

                    body = Expression.Convert(callExpr, returnType);
                }

                var lambda = Expression.Lambda(type, body, parameters);
                return lambda.Compile();
            }

            // Arrays -> empty array
            if (type.IsArray)
            {
                var elem = type.GetElementType();
                return Array.CreateInstance(elem, 0);
            }

            // Primitive / string -> default
            if (type == typeof(string))
                return string.Empty;

            if (type.GetTypeInfo().IsPrimitive || type.IsEnum)
                return Activator.CreateInstance(type);

            // Classes: choose constructor with most parameters
            var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                                   .OrderByDescending(c => c.GetParameters().Length)
                                   .ToArray();

            foreach (var ctor in constructors)
            {
                var parameters = ctor.GetParameters();
                try
                {
                    var args = parameters.Select(p => Create(p.ParameterType)).ToArray();
                    var instance = ctor.Invoke(args);
                    return instance;
                }
                catch
                {
                    // try next ctor
                }
            }

            // Fallback: try parameterless
            try
            {
                return Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Cannot create instance of type {type.FullName}", ex);
            }
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public T Freeze<T>()
        {
            var type = typeof(T);
            if (_frozen.TryGetValue(type, out var existing))
                return (T)existing;

            var value = Create<T>();
            _frozen[type] = value!;
            return value;
        }

        public object Freeze(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (_frozen.TryGetValue(type, out var existing))
                return existing;

            var value = Create(type);
            _frozen[type] = value!;
            return value;
        }

        public void RegisterNull(Type type)
        {
            _nullTypes[type] = true;
        }
    }
}
