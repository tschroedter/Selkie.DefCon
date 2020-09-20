// ReSharper disable NotAccessedField.Local

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    public class TestClassWithInterface
    {
        private readonly ISomething _something ;
        private readonly TestClass  _testClass ;
        private readonly string     _text ;
        private readonly int        _value ;

        public TestClassWithInterface ( TestClass  testClass ,
                                        ISomething something ,
                                        string     text ,
                                        int        value )
        {
            _testClass = testClass ;
            _something = something ;
            _text      = text ;
            _value     = value ;
        }
    }
}