using System ;
using FluentAssertions ;
using JetBrains.Annotations ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common ;

[ TestClass ]
public class ParameterInstanceCreatorTests
{
    private Type _type ;

    [ TestMethod ]
    public void Create_ForCorrectParameters_ReturnsParameters ( )
    {
        _type = typeof ( TestClassWithInterface ) ;

        CreateSut ( )
           .Create ( _type )
           .Should ( )
           .BeOfType ( _type ) ;
    }

    [ TestMethod ]
    public void Create_ForTypeIsNull_Throws ( )
    {
        _type = null ;

        Action action = ( ) => CreateSut ( )
                           .Create ( _type! ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "parameterType" ) ;
    }

    [ TestMethod ]
    public void Create_ForTypeWithDependencyOnClassNoPublicConstructor_Throws ( )
    {
        _type = typeof ( TestClassWithDependencyOnClassNoPublicConstructor ) ;

        Action action = ( ) => CreateSut ( )
                           .Create ( _type ) ;

        action.Should ( )
              .Throw < ArgumentException > ( )
              .And.ParamName.Should ( )
              .Be ( "parameterType" ) ;
    }

    [ TestInitialize ]
    public void Setup ( )
    {
    }

    private ParameterInstanceCreator CreateSut ( )
    {
        return new ParameterInstanceCreator ( ) ;
    }

    public class TestClassWithDependencyOnClassNoPublicConstructor ( TestClassWithNoPublicConstructor @class )
    {
        [ UsedImplicitly ]
        private readonly TestClassWithNoPublicConstructor _class = @class ;
    }

    public class TestClassWithNoPublicConstructor
    {
        protected TestClassWithNoPublicConstructor ( )
        {
        }
    }
}