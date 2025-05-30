using JetBrains.Annotations ;

// ReSharper disable NotAccessedField.Local

namespace Selkie.DefCon.One.DotNetCore.Tests.Common ;

[ method : UsedImplicitly ]
public class TestClassTwoConstructors ( TestClass testClass ,
                                        ISomething something ,
                                        string text ,
                                        int value )
{
    [ UsedImplicitly ]
    public TestClassTwoConstructors ( TestClass testClass ,
                                      ISomething something )
        : this ( testClass ,
                 something ,
                 string.Empty ,
                 0 )
    {
    }

    [ UsedImplicitly ]
    public TestClass TestClass { get ; } = testClass ;

    [ UsedImplicitly ]
    public ISomething Something { get ; } = something ;

    [ UsedImplicitly ]
    public string Text { get ; } = text ;

    [ UsedImplicitly ]
    public int Value { get ; } = value ;
}