using System ;
using System.Collections.Generic ;
using System.Reflection ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces ;

public interface IConstructorInfoProvider : IEnumerable < ConstructorInfo >
{
    [ NotNull ]
    Type Type { get ; }

    int Length { get ; }

    [ NotNull ]
    ConstructorInfo this [ int index ] { get ; }

    IConstructorInfoProvider SetType ( [ NotNull ] Type type ) ;
}