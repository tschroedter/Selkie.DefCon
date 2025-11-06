using System.Reflection ;
using Autofac ;
using AutofacSerilogIntegration ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;
using Selkie.DefCon.One.Test.Examples ;
using Serilog ;
using Serilog.Events ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Constructor ;

[ TestClass ]
public class NotNullAssemblyTesterTests
{
    private IContainer _container ;

    [ TestCleanup ]
    public void Cleanup ( )
    {
        _container.Dispose ( ) ;
    }

    [ TestMethod ]
    public void Constructor_ForAnyParameterNull_Throws ( )
    {
        // ReSharper disable once AssignNullToNotNullAttribute
        CreateSut ( )
           .Test ( Assembly.GetAssembly ( typeof ( ExamplePassing ) ) ) ;
    }

    [ TestInitialize ]
    public void Initialize ( )
    {
        const string template = "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] " +
                                "{Message} (at {Caller}){NewLine}{Exception}" ;

        Log.Logger = new LoggerConfiguration ( )
                    .Enrich.WithCaller ( )
                    .MinimumLevel.Information ( )
                    .WriteTo.Console ( LogEventLevel.Debug ,
                                       template )
                    .CreateLogger ( ) ;

        var builder = new ContainerBuilder ( ) ;

        builder.RegisterLogger ( ) ;
        builder.RegisterModule < DefConOneModule > ( ) ;

        _container = builder.Build ( ) ;
    }

    private INotNullAssemblyTester CreateSut ( )
    {
        return _container.Resolve < INotNullAssemblyTester > ( ) ;
    }
}