using System ;
using System.Linq ;
using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using NSubstitute ;
using Selkie.DefCon.One.Constructor ;
using Selkie.DefCon.One.DotNetCore.Tests.Common ;
using Serilog ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Constructor ;

[ TestClass ]
public class ConstructorInfoProviderTests
{
    private ILogger _logger ;

    [ TestMethod ]
    public void Constructor_ForLoggerNull_Throws ( )
    {
        _logger = null ;

        var action = new Action ( ( ) => CreateSut ( ) ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "logger" ) ;
    }

    [ TestMethod ]
    public void SetType_ForLength_SetsLength ( )
    {
        var expected = typeof ( TestClass ).GetConstructors ( )
                                           .Length ;

        CreateSut ( )
           .SetType ( typeof ( TestClass ) )
           .Length
           .Should ( )
           .Be ( expected ) ;
    }

    [ TestMethod ]
    public void SetType_ForType_GetEnumerator ( )
    {
        var expected = typeof ( TestClass ).GetConstructors ( )
                                           .Length ;

        CreateSut ( )
           .SetType ( typeof ( TestClass ) )
           .Select ( x => x.ToString ( ) )
           .Count ( )
           .Should ( )
           .Be ( expected ) ;
    }

    [ TestMethod ]
    public void SetType_ForType_SetsLength ( )
    {
        CreateSut ( )
           .SetType ( typeof ( TestClass ) ) [ 0 ]
           .Should ( )
           .NotBeNull ( ) ;
    }


    [ TestMethod ]
    public void SetType_ForType_SetsType ( )
    {
        CreateSut ( )
           .SetType ( typeof ( TestClass ) )
           .Type
           .Should ( )
           .Be ( typeof ( TestClass ) ) ;
    }

    [ TestMethod ]
    public void SetType_ForTypeNull_Throws ( )
    {
        // ReSharper disable once AssignNullToNotNullAttribute
        var action = new Action ( ( ) => CreateSut ( )
                                     .SetType ( null ) ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "type" ) ;
    }

    [ TestInitialize ]
    public void Setup ( )
    {
        _logger = Substitute.For < ILogger > ( ) ;
    }

    private ConstructorInfoProvider CreateSut ( )
    {
        return new ConstructorInfoProvider ( _logger ) ;
    }
}