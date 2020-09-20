using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;

// ReSharper disable NotAccessedField.Local

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    // todo implement TestIgnore
    public class TestClassWithAttribute
    {
        private readonly ISomething _something ;
        private readonly int        _value ;

        [ UsedImplicitly ]
        public TestClassWithAttribute ( [ GuardIgnore ] int        value ,
                                        [ GuardIgnore ] ISomething something )
        {
            _value     = value ;
            _something = something ;
        }
    }
}