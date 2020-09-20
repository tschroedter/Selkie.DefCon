using System ;
using System.Reflection ;

namespace Selkie.DefCon.One.Interfaces
{
    public interface IPublicClassesFinder
    {
        Type [ ] DefinedTypes    { get ; }
        Type [ ] AllDefinedTypes { get ; }
        Type [ ] IgnoredTypes    { get ; }
        Assembly DefinedAssembly { get ; } // todo check CanBeNull?
        void     LoadTypes ( Assembly assembly ) ;
    }
}