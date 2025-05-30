using System ;
using System.Linq ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.Constructor
{
    public class PublicClassesFinder
        : IPublicClassesFinder
    {
        private readonly IPublicClassesFinderToStringConverter _converter ;

        public PublicClassesFinder ( [ NotNull ] IPublicClassesFinderToStringConverter converter )
        {
            Guard.ArgumentNotNull ( converter ,
                                    nameof ( converter ) ) ;

            _converter = converter ;
        }

        public void LoadTypes ( Assembly assembly )
        {
            DefinedAssembly = assembly ;

            AllDefinedTypes = assembly.GetTypes ( ) ;

            DefinedTypes = AllDefinedTypes.Where ( IsClass )
                                          .Where ( x => ! IsDelegate ( x ) )
                                          .ToArray ( ) ;

            IgnoredTypes = AllDefinedTypes.Except ( DefinedTypes )
                                          .ToArray ( ) ;
        }

        public Assembly DefinedAssembly { get ; private set ; } // todo check CanBeNull?

        public Type [ ] IgnoredTypes { get ; private set ; }

        public Type [ ] DefinedTypes { get ; private set ; }

        public Type [ ] AllDefinedTypes { get ; private set ; }

        public override string ToString ( )
        {
            return _converter.Convert ( this ) ;
        }

        private static bool IsClass ( Type type )
        {
            return type.IsClass && ! type.IsAbstract && ! type.IsInterface ;
        }

        private static bool IsDelegate ( Type type )
        {
            var baseType = type ;

            while ( baseType != null )
            {
                if ( baseType.BaseType is { FullName: not null } &&
                     baseType.BaseType.FullName.Contains ( "System.MulticastDelegate" ) )
                    return true ; // todo log ignored delegate

                baseType = baseType.BaseType ;
            }

            return false ;
        }
    }
}