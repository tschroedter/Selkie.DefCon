using System.Collections ;
using System.Collections.Generic ;
using System.Diagnostics.CodeAnalysis ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Extensions ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.Constructor
{
    public class FailedConstructorCalls
        : IFailedConstructorCalls
    {
        private readonly Dictionary < string , List < DefConConstructorInfo > > _dictionary = new ( ) ;

        private readonly ILogger _logger ;

        public FailedConstructorCalls ( [ JetBrains.Annotations.NotNull ] ILogger logger )
        {
            Guard.ArgumentNotNull ( logger ,
                                    nameof ( logger ) ) ;

            _logger = logger ;
        }

        public List < DefConConstructorInfo > this [ string i ] => _dictionary [ i ] ;

        public IFailedConstructorCalls Add ( IEnumerable < DefConConstructorInfo > failed )
        {
            foreach ( var failedConstructorInfo in failed )
            {
                var key = failedConstructorInfo.ConstructorInfo.ToText ( ) ;

                if ( ! _dictionary.TryGetValue ( key ,
                                                 out var list ) )
                {
                    list = [] ;

                    _dictionary [ key ] = list ;

                    _logger.Information ( $"{key}" ) ;
                }

                list.Add ( failedConstructorInfo ) ;
            }

            return this ;
        }

        public IEnumerator < string > GetEnumerator ( )
        {
            foreach ( var key in _dictionary.Keys )
            {
                yield return key ;
            }
        }

        [ ExcludeFromCodeCoverage ]
        IEnumerator IEnumerable.GetEnumerator ( )
        {
            return GetEnumerator ( ) ;
        }

        public int Count => _dictionary.Count ;

        public IFailedConstructorCalls Clear ( )
        {
            _dictionary.Clear ( ) ;

            return this ;
        }
    }
}