using System ;
using System.Reflection ;
using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using NSubstitute ;
using Selkie.DefCon.One.Constructor ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Constructor ;

[ TestClass ]
public class PublicClassesFinderToStringConverterTests
{
    private IPublicClassesFinder _finder ;

    [ TestMethod ]
    public void Convert_ForFinder_ReturnsString ( )
    {
        CreateSut ( )
           .Convert ( _finder )
           .Should ( )
           .StartWith ( "Found " ) ;
    }

    [ TestMethod ]
    public void Convert_ForFinderIsNull_Throws ( )
    {
        _finder = null ;

        Action action = ( ) => CreateSut ( )
                           .Convert ( _finder! ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "finder" ) ;
    }

    [ TestInitialize ]
    public void Setup ( )
    {
        _finder = new PublicClassesFinder ( Substitute.For < IPublicClassesFinderToStringConverter > ( ) ) ;
        _finder.LoadTypes ( Assembly.GetExecutingAssembly ( ) ) ;
    }

    private PublicClassesFinderToStringConverter CreateSut ( )
    {
        return new PublicClassesFinderToStringConverter ( ) ;
    }
}