using System ;
using System.Collections.Generic ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.Interfaces ;

public interface ICallingInformationProvider
    : IEnumerable < CallingInformation >
{
    CallingInformation this [ int index ] { get ; }

    int ConstructorsToTest { get ; }

    [ NotNull ]
    Type InstanceType { get ; }

    void Find ( ) ;

    void SetType ( [ NotNull ] Type type ) ;
}