using System ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.Common ;

public class NotNullTesterResult
{
    public NotNullTesterResult ( [ NotNull ] INotNullTester notNullTester )
    {
        Guard.ArgumentNotNull ( notNullTester ,
                                nameof ( notNullTester ) ) ;

        HasPassed     = notNullTester.HasPassed ;
        TestValue     = notNullTester.TestValue ;
        ExceptionType = notNullTester.ExceptionType ;
        InstanceType  = notNullTester.InstanceType ;
        ToTest        = notNullTester.ConstructorsToTest ;
        Failed        = notNullTester.ConstructorsFailed ;
    }

    public bool HasPassed { get ; }

    [ CanBeNull ]
    public object TestValue { get ; }

    public Type ExceptionType { get ; }

    public Type InstanceType { get ; }

    public int ToTest { get ; }

    public int Failed { get ; }
}