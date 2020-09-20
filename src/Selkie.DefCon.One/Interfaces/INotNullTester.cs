using System ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces
{
    public interface INotNullTester
    {
        bool   HasPassed          { get ; }
        object TestValue          { get ; }
        Type   ExceptionType      { get ; }
        Type   InstanceType       { get ; }
        int    ConstructorsToTest { get ; }
        int    ConstructorsFailed { get ; }

        [ NotNull ]
        INotNullTester Test ( Type instanceType ) ;

        [ NotNull ]
        INotNullTester Test < T > ( )
            where T : class ;
    }
}