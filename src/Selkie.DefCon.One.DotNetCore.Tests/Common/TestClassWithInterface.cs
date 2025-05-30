// ReSharper disable NotAccessedField.Local

using JetBrains.Annotations ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common ;

public class TestClassWithInterface ( TestClass testClass ,
                                      ISomething something ,
                                      string text ,
                                      int value )
{
    [ UsedImplicitly ]
    public TestClass TestClass { get ; } = testClass ;

    [ UsedImplicitly ]
    public ISomething Something { get ; } = something ;

    [ UsedImplicitly ]
    public string Text { get ; } = text ;

    [ UsedImplicitly ]
    public int Value { get ; } = value ;
}