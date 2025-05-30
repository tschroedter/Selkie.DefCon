using JetBrains.Annotations ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common ;

public class TestClass ( int value )
{
    [ UsedImplicitly ]
    private readonly int _value = value ;
}