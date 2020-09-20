using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    public class TestClassWithInterfaceAndGuard
        : TestClassWithInterface
    {
        public TestClassWithInterfaceAndGuard ( [ NotNull ] TestClass  testClass ,
                                                [ NotNull ] ISomething something ,
                                                [ NotNull ] string     text ,
                                                int                    value )
            : base ( testClass ,
                     something ,
                     text ,
                     value )
        {
            Guard.ArgumentNotNull ( text ,
                                    nameof ( text ) ) ;
            Guard.ArgumentNotNull ( testClass ,
                                    nameof ( testClass ) ) ;
            Guard.ArgumentNotNull ( something ,
                                    nameof ( something ) ) ;
        }
    }
}