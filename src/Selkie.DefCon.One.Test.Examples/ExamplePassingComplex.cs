using System ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.Test.Examples
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class ExamplePassingComplex
    {
        public ExamplePassingComplex ( [ NotNull ] Func < DateTimeOffset , IDateTimeOffset > dateTimeFactory )
        {
            Guard.ArgumentNotNull ( dateTimeFactory , nameof ( dateTimeFactory ) ) ;
        }
    }

    public interface IDateTimeOffset
    {
    }
}