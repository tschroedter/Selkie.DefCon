using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.Constructor
{
    [ UsedImplicitly ]
    public class CallingInformationProvider
        : ICallingInformationProvider
    {
        private static readonly CallingInformation [ ] Empty = [] ;

        private readonly List < ConstructorInfo > _constructorsToTest =
            [] ;

        private readonly ILogger _logger ;

        [ NotNull ] private readonly IConstructorInfoProvider _provider ;

        private CallingInformation [ ] _constructors = Empty ;

        public CallingInformationProvider ( [ NotNull ] ILogger                  logger ,
                                            [ NotNull ] IConstructorInfoProvider provider )
        {
            Guard.ArgumentNotNull ( logger ,
                                    nameof ( logger ) ) ;
            Guard.ArgumentNotNull ( provider ,
                                    nameof ( provider ) ) ;

            _logger   = logger ;
            _provider = provider ;
        }

        public bool FindAllReferenceTypes { get ; set ; } = true ;

        public int ConstructorsToTest => _constructorsToTest.Count ;

        public void Find ( )
        {
            _logger.Information ( $"Found {_provider.Length} Constructors for " +
                                  $"'{_provider.Type.FullName}'" ) ;

            _constructorsToTest.Clear ( ) ;

            var infos = new List < CallingInformation > ( ) ;

            foreach ( var constructor in _provider )
            {
                foreach ( var parameter in constructor.GetParameters ( ) )
                {
                    if ( FindAllReferenceTypes )
                        if ( parameter.ParameterType.IsValueType )
                            continue ;

                    if ( ! _constructorsToTest.Contains ( constructor ) ) _constructorsToTest.Add ( constructor ) ;

                    infos.Add ( new CallingInformation ( constructor ,
                                                         parameter ) ) ;
                }
            }

            _constructors = infos.ToArray ( ) ;
        }

        public Type InstanceType => _provider.Type ;

        public void SetType ( Type type )
        {
            Guard.ArgumentNotNull ( type ,
                                    nameof ( type ) ) ;

            _provider.SetType ( type ) ;
        }

        public IEnumerator < CallingInformation > GetEnumerator ( )
        {
            return ( ( IEnumerable < CallingInformation > ) _constructors ).GetEnumerator ( ) ;
        }

        IEnumerator IEnumerable.GetEnumerator ( )
        {
            return GetEnumerator ( ) ;
        }

        public CallingInformation this [ int index ] => _constructors [ index ] ;
    }
}