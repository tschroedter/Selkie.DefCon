using Autofac ;
using AutofacSerilogIntegration ;
using FluentAssertions ;
using FluentAssertions.Execution ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;
using Selkie.DefCon.One.Test.Examples ;
using Serilog ;
using Serilog.Events ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Constructor
{
    [ TestClass ]
    public class NotNullTesterTests
    {
        private IContainer _container ;

        [ TestCleanup ]
        public void Cleanup ( )
        {
            _container.Dispose ( ) ;
        }

        [ TestMethod ]
        public void Constructor_ForAnyParameterNullThrows_AllPassing ( )
        {
            var sut = CreateSut ( ) ;

            sut.Test < ExamplePassing > ( ) ;

            using ( new AssertionScope ( ) )
            {
                sut.HasPassed
                   .Should ( )
                   .BeTrue ( ) ;

                sut.ConstructorsToTest
                   .Should ( )
                   .Be ( 6 ) ;

                sut.ConstructorsFailed
                   .Should ( )
                   .Be ( 0 ) ;
            }
        }

        [ TestMethod ]
        public void Constructor_ForAnyParameterNullThrows_AllFailing ( )
        {
            var sut = CreateSut ( ) ;

            sut.Test < ExampleFalling > ( ) ;

            using ( new AssertionScope ( ) )
            {
                sut.HasPassed
                   .Should ( )
                   .BeFalse ( ) ;

                sut.ConstructorsToTest
                   .Should ( )
                   .Be ( 6 ) ;

                sut.ConstructorsFailed
                   .Should ( )
                   .Be ( 6 ) ;
            }
        }

        [TestMethod]
        public void Constructor_ForAnyParameterNullAndIgnored_AllPassing()
        {
            var sut = CreateSut();

            sut.Test<ExamplePassingWithIgnore>();

            using (new AssertionScope())
            {
                sut.HasPassed
                   .Should()
                   .BeTrue();

                sut.ConstructorsToTest
                   .Should()
                   .Be(1);

                sut.ConstructorsFailed
                   .Should()
                   .Be(0);
            }
        }

        [TestInitialize ]
        public void Initialize ( )
        {
            const string template =
                "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message}{NewLine}{Exception}" ;
            // "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message} (at {Caller}){NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration ( )
                        .Enrich.WithCaller ( )
                        .MinimumLevel.Information ( )
                        .WriteTo.ColoredConsole ( LogEventLevel.Debug , template )
                        .CreateLogger ( ) ;

            var builder = new ContainerBuilder ( ) ;

            builder.RegisterLogger ( ) ;
            builder.RegisterModule < DefConOneModule > ( ) ;

            _container = builder.Build ( ) ;
        }

        private INotNullTester CreateSut ( )
        {
            return _container.Resolve < INotNullTester > ( ) ;
        }
    }
}