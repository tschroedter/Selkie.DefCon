using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;

// ReSharper disable NotAccessedField.Local

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    // todo implement TestIgnore
    [ method : UsedImplicitly ]
    public class TestClassWithAttribute ( [ GuardIgnore ] int value ,
                                          [ GuardIgnore ] ISomething something )
    {
        [UsedImplicitly] public int Value { get ; } = value ;
        [UsedImplicitly] public ISomething Something { get ; } = something ;
    }
}