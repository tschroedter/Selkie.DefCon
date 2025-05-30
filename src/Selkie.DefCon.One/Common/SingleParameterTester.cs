using System ;
using System.Linq ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.Common ;

[ UsedImplicitly ]
public class SingleParameterTester : ISingleParameterTester
{
    [ NotNull ]
    private readonly IResultMessageBuilder _builder ;

    [ NotNull ]
    private readonly IInstanceCreator _creator ;

    [ NotNull ]
    private readonly ILogger _logger ;

    [ NotNull ]
    private readonly IParameterCreator _parameterCreator ;

    public SingleParameterTester ( [ NotNull ] ILogger               logger ,
                                   [ NotNull ] IResultMessageBuilder builder ,
                                   [ NotNull ] IParameterCreator     parameterCreator ,
                                   [ NotNull ] IInstanceCreator      instanceCreator )
    {
        Guard.ArgumentNotNull ( logger ,
                                nameof ( logger ) ) ;
        Guard.ArgumentNotNull ( builder ,
                                nameof ( builder ) ) ;
        Guard.ArgumentNotNull ( parameterCreator ,
                                nameof ( parameterCreator ) ) ;
        Guard.ArgumentNotNull ( instanceCreator ,
                                nameof ( instanceCreator ) ) ;

        _logger           = logger ;
        _builder          = builder ;
        _parameterCreator = parameterCreator ;
        _creator          = instanceCreator ;
    }

    public bool Test ( ConstructorInfo   info ,
                       Type              instanceType ,
                       ParameterInfo [ ] arrayParameter ,
                       object            value ,
                       Type              exceptionType ,
                       int               index )
    {
        var parameterTypes = arrayParameter.Select ( parameterInfo => parameterInfo.ParameterType )
                                           .ToArray ( ) ;

        var parameters = _parameterCreator.Create ( instanceType ,
                                                    arrayParameter ,
                                                    index ,
                                                    value ) ;

        var result = _creator.ConstructionThrows ( instanceType ,
                                                   parameterTypes ,
                                                   parameters ,
                                                   exceptionType ) ;

        _builder.WithConstructorInfo ( info )
                .WithType ( instanceType )
                .WithParameters ( arrayParameter )
                .WithTestParameterAtIndex ( index )
                .WithTestParameterValue ( value )
                .WithException ( exceptionType )
                .WithResult ( result ) ;

        _logger.Information ( $"{_builder.Create ( )}" ) ;

        return result ;
    }
}