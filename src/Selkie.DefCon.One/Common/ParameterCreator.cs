using System ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.Common
{
    /// <inheritdoc />
    [ UsedImplicitly ]
    public class ParameterCreator : IParameterCreator
    {
        private readonly IParameterInstanceCreator _creator ;

        public ParameterCreator ( [ NotNull ] IParameterInstanceCreator creator )
        {
            Guard.ArgumentNotNull ( creator ,
                                    nameof ( creator ) ) ;

            _creator = creator ;
        }

        /// <inheritdoc />
        public object [ ] Create ( Type              type ,
                                   ParameterInfo [ ] arrayParameter ,
                                   int               parameterIndex ,
                                   object            parameterValue )
        {
            Guard.ArgumentNotNull ( type ,
                                    nameof ( type ) ) ;
            Guard.ArgumentNotNull ( arrayParameter ,
                                    nameof ( arrayParameter ) ) ;
            Guard.ArgumentBetween ( parameterIndex ,
                                    nameof ( parameterIndex ) ,
                                    0 ,
                                    arrayParameter.Length - 1 ) ;

            var parameters = _creator.Create ( arrayParameter ) ;

            parameters [ parameterIndex ] = parameterValue ;

            return parameters ;
        }
    }
}