using System ;
using System.Collections.Generic ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Interfaces ;
using Selkie.DefCon.One.Interfaces.Arguments ;

namespace Selkie.DefCon.One.Common ;

/// <inheritdoc />
[ UsedImplicitly ]
public class ParameterCreator : IParameterCreator
{
    private readonly IArgumentsGenerator _creator ;

    public ParameterCreator ( [ NotNull ] IArgumentsGenerator creator ) // todo rename Arguments or ParameterCreator
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

        var parameters = _creator.Create ( ToParameterInfos ( arrayParameter ) ) ;

        parameters [ parameterIndex ] = parameterValue ;

        return parameters ;
    }

    private static List < IParameterInfo > ToParameterInfos ( ParameterInfo [ ] arrayParameter )
    {
        var list = new List < IParameterInfo > ( ) ;

        foreach ( var parameterInfo in arrayParameter )
        {
            list.Add ( new Arguments.ParameterInfo ( parameterInfo ) ) ;
        }

        return list ;
    }
}