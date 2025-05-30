using System ;
using System.Linq ;
using System.Reflection ;
using NSubstitute ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.Common
{
    /// <inheritdoc />
    public class ParameterInstanceCreator
        : IParameterInstanceCreator
    {
        internal const string IgnoreMe = "IgnoreMe" ;

        /// <inheritdoc />
        public object Create ( Type parameterType )
        {
            Guard.ArgumentNotNull ( parameterType ,
                                    nameof ( parameterType ) ) ;

            if ( HasDefaultConstructor ( parameterType ) ||
                 parameterType.IsValueType )
                return CreateInstance ( parameterType ) ;

            return CreateInstanceForReferenceType ( parameterType ) ;
        }

        /// <inheritdoc />
        public object Create ( ParameterInfo parameterInfo )
        {
            Guard.ArgumentNotNull ( parameterInfo ,
                                    nameof ( parameterInfo ) ) ;


            var parameterType = parameterInfo.ParameterType ;

            if ( parameterType.IsInterface   ||
                 parameterType.IsGenericType ||
                 parameterType == typeof ( Delegate ) )
                return Substitute.For ( [
                                            parameterType
                                        ] ,
                                        [] ) ;

            return parameterType == typeof ( string )
                       ? IgnoreMe
                       : Create ( parameterType ) ;
        }

        /// <inheritdoc />
        public object [ ] Create ( ParameterInfo [ ] arrayParameter )
        {
            var parameters = new object[ arrayParameter.Length ] ;

            for ( var index = 0 ; index < arrayParameter.Length ; index ++ )
            {
                parameters [ index ] = Create ( arrayParameter [ index ] ) ;
            }

            return parameters ;
        }

        internal static bool HasDefaultConstructor ( Type parameterType )
        {
            return parameterType.GetConstructors ( BindingFlags.Default )
                                .Length ==
                   1 ;
        }

        private static object CreateInstance(Type parameterType)
        {
            var instance = Activator.CreateInstance(parameterType);

            if (instance == null)
                throw new InvalidOperationException($"Failed to create instance of type {parameterType.FullName}");

            return instance;
        }

        private object CreateInstanceForReferenceType ( Type parameterType )
        {
            var constructor = parameterType.GetConstructors ( )
                                           .FirstOrDefault ( ) ;

            if ( constructor == null )
                throw new ArgumentException ( $"{parameterType} doesn't have a public Constructor'" ,
                                              nameof ( parameterType ) ) ;

            var args = Create ( constructor.GetParameters ( ) ) ;

            return Activator.CreateInstance ( parameterType ,
                                              args ) ;
        }
    }
}