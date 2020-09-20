using System ;
using System.Reflection ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces
{
    public interface ISingleParameterTester
    {
        bool Test ( [ NotNull ]   ConstructorInfo   info ,
                    [ NotNull ]   Type              instanceType ,
                    [ NotNull ]   ParameterInfo [ ] arrayParameter ,
                    [ CanBeNull ] object            value ,
                    [ NotNull ]   Type              exceptionType ,
                    int                             index ) ;
    }
}