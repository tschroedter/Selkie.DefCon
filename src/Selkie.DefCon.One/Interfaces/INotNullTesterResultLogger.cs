using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.Interfaces ;

public interface INotNullTesterResultLogger
{
    void LogResult ( [ NotNull ] NotNullTesterResult result ) ;
}