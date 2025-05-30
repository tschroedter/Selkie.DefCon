using System ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces ;

// ReSharper disable once UnusedTypeParameter
public interface IInstanceCreator
{
    bool ConstructionThrows ( [ NotNull ] Type       instanceType ,
                              [ NotNull ] Type [ ]   parametersTypes ,
                              [ NotNull ] object [ ] parameterValues ,
                              [ NotNull ] Type       exceptionType ) ;
}