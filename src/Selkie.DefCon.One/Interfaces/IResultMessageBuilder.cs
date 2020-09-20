using System ;
using System.Reflection ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces
{
    public interface IResultMessageBuilder
    {
        [ NotNull ]
        string Create ( ) ;

        IResultMessageBuilder WithConstructorInfo ( [ NotNull ] ConstructorInfo info ) ;
        IResultMessageBuilder WithException ( Type                              type ) ;
        IResultMessageBuilder WithParameters ( [ NotNull ] ParameterInfo [ ]    parameters ) ;
        IResultMessageBuilder WithResult ( bool                                 result ) ;
        IResultMessageBuilder WithTestParameterAtIndex ( int                    indexOfNullParameter ) ;
        IResultMessageBuilder WithTestParameterValue ( object                   value ) ;
        IResultMessageBuilder WithType ( [ NotNull ] Type                       type ) ;
    }
}