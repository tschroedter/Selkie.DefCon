using System;

namespace Selkie.DefCon.One.Arguments
{
    public interface IObjectFactory
    {
        object Create(Type type);

        T Create<T>();

        T Freeze<T>();

        object Freeze(Type type);

        void RegisterNull(Type type);
    }
}
