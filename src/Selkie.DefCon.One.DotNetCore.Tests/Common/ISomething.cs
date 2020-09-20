using JetBrains.Annotations ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    public interface ISomething
    {
        [ UsedImplicitly ]
        void DoNothing ( ) ;
    }
}