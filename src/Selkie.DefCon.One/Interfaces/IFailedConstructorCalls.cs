using System.Collections.Generic ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.Interfaces ;

public interface IFailedConstructorCalls
    : IEnumerable < string >
{
    List < DefConConstructorInfo > this [ string i ] { get ; }
    int                     Count { get ; }
    IFailedConstructorCalls Add ( IEnumerable < DefConConstructorInfo > failed ) ;
    IFailedConstructorCalls Clear ( ) ;
}