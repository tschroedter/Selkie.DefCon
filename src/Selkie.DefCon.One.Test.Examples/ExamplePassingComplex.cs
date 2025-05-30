using System ;
using System.Diagnostics.CodeAnalysis ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.Test.Examples ;

[ ExcludeFromCodeCoverage ]
public class ExamplePassingComplex
{
    public ExamplePassingComplex (
        [ JetBrains.Annotations.NotNull ] Func < DateTimeOffset , IDateTimeOffset > dateTimeFactory )
    {
        Guard.ArgumentNotNull ( dateTimeFactory ,
                                nameof ( dateTimeFactory ) ) ;
    }
}

// ReSharper disable once RedundantTypeDeclarationBody
public interface IDateTimeOffset
{
}

public class DeviceFactory
{
    [ UsedImplicitly ]
    private readonly Device.Factory _factory ;

    public DeviceFactory ( [ JetBrains.Annotations.NotNull ] Device.Factory factory )
    {
        Guard.ArgumentNotNull ( factory ,
                                nameof ( factory ) ) ;

        _factory = factory ;
    }
}

public class Device
{
    public delegate Device Factory ( ) ;
}