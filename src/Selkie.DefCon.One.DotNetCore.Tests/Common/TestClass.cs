using JetBrains.Annotations ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    public class TestClass
    {
        [ UsedImplicitly ] private readonly int _value ;

        public TestClass ( int value )
        {
            _value = value ;
        }
    }
}