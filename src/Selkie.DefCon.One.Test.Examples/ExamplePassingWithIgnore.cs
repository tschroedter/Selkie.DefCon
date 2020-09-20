using System.Diagnostics.CodeAnalysis ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.Test.Examples
{
    [ ExcludeFromCodeCoverage ]
    public class ExamplePassingWithIgnore
        : ExampleBase
    {
        public ExamplePassingWithIgnore ( [ GuardIgnore ] object object1 )
        {
            Object1 = object1 ;
        }
    }
}