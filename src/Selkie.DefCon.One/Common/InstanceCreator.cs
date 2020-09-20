using System ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Extensions ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.Common
{
    [ UsedImplicitly ]
    public class InstanceCreator
        : IInstanceCreator
    {
        private readonly ILogger _logger ;

        public InstanceCreator ( [ NotNull ] ILogger logger )
        {
            Guard.ArgumentNotNull ( logger ,
                                    nameof ( logger ) ) ;

            _logger = logger ;
        }

        public bool ConstructionThrows ( Type       instanceType ,
                                         Type [ ]   parametersTypes ,
                                         object [ ] parameterValues ,
                                         Type       exceptionType )

        {
            Guard.ArgumentNotNull ( instanceType ,
                                    nameof ( instanceType ) ) ;
            Guard.ArgumentNotNull ( parametersTypes ,
                                    nameof ( parametersTypes ) ) ;
            Guard.ArgumentNotNull ( parameterValues ,
                                    nameof ( parameterValues ) ) ;
            Guard.ArgumentNotNull ( exceptionType ,
                                    nameof ( exceptionType ) ) ;

            try
            {
                var ci = CreateInstance ( instanceType ,
                                          parametersTypes ) ;

                ci.Invoke ( parameterValues ) ;
            }
            catch ( Exception e )
            {
                var actualException = e.InnerException?.GetType ( ) ;

                if ( actualException == exceptionType ) return true ;

                _logger.Debug ( $"Expected '{exceptionType}' but a " +
                                $"'{actualException}' was thrown!" ) ;
            }

            return false ;
        }

        private static ConstructorInfo CreateInstance ( Type     instanceType ,
                                                        Type [ ] parametersTypes )
        {
            var ci = instanceType.GetConstructor ( parametersTypes ) ;

            if ( ci == null )
                throw new ArgumentException ( "Can't find constructor for InstanceType " +
                                              $"'{instanceType}' and "                   +
                                              $"({parametersTypes.ToText ( )})" ) ;

            return ci ;
        }
    }
}