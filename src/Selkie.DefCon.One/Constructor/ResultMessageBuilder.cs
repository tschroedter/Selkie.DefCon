using System ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Extensions ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.Constructor ;

[ UsedImplicitly ]
public class ResultMessageBuilder : IResultMessageBuilder
{
    private Type              _exceptionType ;
    private int               _indexOfTestParameter ;
    private ConstructorInfo   _info ;
    private ParameterInfo [ ] _parameters ;
    private bool              _result ;
    private object            _testParameterValue ;
    private Type              _type ;

    public string Create ( )
    {
        var resultText = " NOT " ;
        var status     = "FAILED" ;

        if ( _result )
        {
            resultText = " " ;
            status     = "PASS" ;
        }

        var @static = string.Empty ;

        var access = "" ;

        if ( _info != null )
        {
            @static = _info.IsStatic
                          ? "static "
                          : string.Empty ;
            access = _info.IsPublic
                         ? "public "
                         : string.Empty ;
        }

        var parameters = new object[ _parameters.Length ] ;

        for ( var i = 0 ; i < _parameters.Length ; i ++ )
        {
            if ( i == _indexOfTestParameter )
            {
                parameters [ i ] = _testParameterValue ;
                continue ;
            }

            parameters [ i ] = _parameters [ i ]
               .ParameterType ;
        }

        var constructorText =
            string.Format ( $"{access}{@static}{_type.FullName} ( {parameters.ToText ( )} )" ) ;

        var message = $"[ {status} ] {constructorText} " +
                      $"did{resultText}throw {_exceptionType}." ;

        return message ;
    }

    public IResultMessageBuilder WithConstructorInfo ( ConstructorInfo info )
    {
        _info = info ;

        return this ;
    }

    public IResultMessageBuilder WithParameters ( ParameterInfo [ ] parameters )
    {
        _parameters = parameters ;

        return this ;
    }

    public IResultMessageBuilder WithResult ( bool result )
    {
        _result = result ;

        return this ;
    }

    public IResultMessageBuilder WithType ( Type type )
    {
        _type = type ;

        return this ;
    }

    public IResultMessageBuilder WithException ( Type type )
    {
        _exceptionType = type ;

        return this ;
    }

    public IResultMessageBuilder WithTestParameterAtIndex ( int indexOfNullParameter )
    {
        _indexOfTestParameter = indexOfNullParameter ;

        return this ;
    }

    public IResultMessageBuilder WithTestParameterValue ( object value )
    {
        _testParameterValue = value ;

        return this ;
    }
}