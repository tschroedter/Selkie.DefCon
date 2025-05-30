using System.Reflection ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces ;

public interface INotNullAssemblyTester
{
    void Test ( [ NotNull ] Assembly assembly ) ;
}