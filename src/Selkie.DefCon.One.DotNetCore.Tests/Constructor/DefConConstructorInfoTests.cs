using System ;
using System.Linq ;
using System.Reflection ;
using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.DotNetCore.Tests.Common ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Constructor ;

[ TestClass ]
public class DefConConstructorInfoTests
{
    private ConstructorInfo _constructorInfo ;
    private Type _exceptionType ;
    private Type _instanceType ;
    private ParameterInfo [ ] _parameterInfoArray ;
    private int _testParameterIndex ;
    private object _testParameterValue ;

    [ TestMethod ]
    public void Constructor_ForConstructorInfoIsNull_Throws ( )
    {
        _constructorInfo = null ;

        Action action = ( ) => CreateSut ( ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "constructorInfo" ) ;
    }

    [ TestMethod ]
    public void Constructor_ForInvoked_SetsConstructorInfo ( )
    {
        CreateSut ( )
           .ConstructorInfo
           .Should ( )
           .BeSameAs ( _constructorInfo ) ;
    }

    [ TestMethod ]
    public void Constructor_ForInvoked_SetsExceptionType ( )
    {
        CreateSut ( )
           .ExceptionType
           .Should ( )
           .BeSameAs ( _exceptionType ) ;
    }

    [ TestMethod ]
    public void Constructor_ForInvoked_SetsInstanceType ( )
    {
        CreateSut ( )
           .InstanceType
           .Should ( )
           .Be ( _instanceType ) ;
    }

    [ TestMethod ]
    public void Constructor_ForInvoked_SetsParameterInfoArray ( )
    {
        CreateSut ( )
           .ParameterInfoArray
           .Should ( )
           .BeEquivalentTo ( _parameterInfoArray ) ;
    }

    [ TestMethod ]
    public void Constructor_ForInvoked_SetsTestParameterIndex ( )
    {
        CreateSut ( )
           .TestParameterIndex
           .Should ( )
           .Be ( _testParameterIndex ) ;
    }

    [ TestMethod ]
    public void Constructor_ForInvoked_SetsTestParameterValue ( )
    {
        CreateSut ( )
           .TestParameterValue
           .Should ( )
           .BeEquivalentTo ( _testParameterValue ) ;
    }

    [ TestMethod ]
    public void Constructor_ForParameterInfoArrayIsNull_Throws ( )
    {
        _parameterInfoArray = null ;

        Action action = ( ) => CreateSut ( ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "parameterInfoArray" ) ;
    }

    [ TestMethod ]
    public void Constructor_ForTestParameterIndexIsNegative_Throws ( )
    {
        _testParameterIndex = - 1 ;

        Action action = ( ) => CreateSut ( ) ;

        action.Should ( )
              .Throw < ArgumentException > ( )
              .And.ParamName.Should ( )
              .Be ( "testParameterIndex" ) ;
    }

    [ TestMethod ]
    public void Constructor_ForTypeIsNull_Throws ( )
    {
        _instanceType = null ;

        Action action = ( ) => CreateSut ( ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "instanceType" ) ;
    }

    [ TestInitialize ]
    public void Setup ( )
    {
        _constructorInfo = typeof ( TestClass ).GetConstructors ( )
                                               .First ( ) ;

        _parameterInfoArray = _constructorInfo.GetParameters ( ) ;

        _instanceType = typeof ( TestClass ) ;
        _testParameterValue = null ;
        _testParameterIndex = 0 ;
        _exceptionType = typeof ( ArgumentNullException ) ;
    }

    private DefConConstructorInfo CreateSut ( )
    {
        return new DefConConstructorInfo ( _constructorInfo ,
                                           _instanceType ,
                                           _parameterInfoArray ,
                                           _testParameterValue ,
                                           _testParameterIndex ,
                                           _exceptionType ) ;
    }
}