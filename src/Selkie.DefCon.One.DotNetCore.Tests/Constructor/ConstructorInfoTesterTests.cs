using System ;
using FluentAssertions ;
using JetBrains.Annotations ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using NSubstitute ;
using Selkie.DefCon.One.Constructor ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Constructor ;

[ TestClass ]
public class ConstructorInfoTesterTests
{
    private ILogger                _logger ;
    private ISingleParameterTester _tester ;

    [ TestMethod ]
    public void Constructor_ForLoggerIsNull_Throws ( )
    {
        _logger = null ;

        Action action = ( ) => CreateSut ( ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "logger" ) ;
    }

    [ TestMethod ]
    public void Constructor_ForTesterIsNull_Throws ( )
    {
        _tester = null ;

        Action action = ( ) => CreateSut ( ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "tester" ) ;
    }

    [ TestInitialize ]
    public void Setup ( )
    {
        _logger = Substitute.For < ILogger > ( ) ;
        _tester = Substitute.For < ISingleParameterTester > ( ) ;
    }

    [ UsedImplicitly ] // todo check if tests are missing, check test coverage
    private ConstructorInfoTester CreateSut ( )
    {
        return new ConstructorInfoTester ( _logger ,
                                           _tester ) ;
    }
}