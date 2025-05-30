using System ;
using System.Linq ;
using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using NSubstitute ;
using Selkie.DefCon.One.Common ;
using Serilog ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    [ TestClass ]
    public class InstanceCreatorTests
    {
        private Type       _exceptionType ;
        private ILogger    _logger ;
        private Type [ ]   _parameterTypes ;
        private object [ ] _parameterValues ;
        private Type       _type ;

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
        public void Create_ForExceptionTypeIsNull_Throws ( )
        {
            _exceptionType = null ;

            Action action = ( ) => CreateSut ( )
                               .ConstructionThrows ( _type ,
                                                     _parameterTypes ,
                                                     _parameterValues ,
                                                     _exceptionType! ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "exceptionType" ) ;
        }

        [ TestMethod ]
        public void Create_ForInstanceTypeIsNull_Throws ( )
        {
            _type = null ;

            Action action = ( ) => CreateSut ( )
                               .ConstructionThrows ( _type! ,
                                                     _parameterTypes ,
                                                     _parameterValues ,
                                                     _exceptionType ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "instanceType" ) ;
        }

        [ TestMethod ]
        public void Create_ForOneParametersIsNullAndThrowingException_ReturnsTrue ( )
        {
            _parameterValues [ 0 ] = null ;

            CreateSut ( )
               .ConstructionThrows ( _type ,
                                     _parameterTypes ,
                                     _parameterValues ,
                                     _exceptionType )
               .Should ( )
               .BeTrue ( ) ;
        }

        [ TestMethod ]
        public void Create_ForParametersTypesIsNull_Throws ( )
        {
            _parameterTypes = null ;

            Action action = ( ) => CreateSut ( )
                               .ConstructionThrows ( _type ,
                                                     _parameterTypes! ,
                                                     _parameterValues ,
                                                     _exceptionType ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "parametersTypes" ) ;
        }

        [ TestMethod ]
        public void Create_ForParameterValuesIsNull_Throws ( )
        {
            _parameterValues = null ;

            Action action = ( ) => CreateSut ( )
                               .ConstructionThrows ( _type ,
                                                     _parameterTypes ,
                                                     _parameterValues! ,
                                                     _exceptionType ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "parameterValues" ) ;
        }

        [ TestMethod ]
        public void Create_ForValidParametersButThrowingUnexpectedException_Throws ( )
        {
            _parameterValues [ 0 ] = new object ( ) ;

            CreateSut ( )
               .ConstructionThrows ( _type ,
                                     _parameterTypes ,
                                     _parameterValues ,
                                     _exceptionType )
               .Should ( )
               .BeFalse ( ) ;
        }

        [ TestMethod ]
        public void Create_ForValidParametersNotThrowingException_ReturnsFalse ( )
        {
            CreateSut ( )
               .ConstructionThrows ( _type ,
                                     _parameterTypes ,
                                     _parameterValues ,
                                     _exceptionType )
               .Should ( )
               .BeFalse ( ) ;
        }

        [ TestMethod ]
        public void Create_ForNoConstructorForParameterTypes_Throws ( )
        {
            _parameterTypes = [typeof ( object )] ;

            CreateSut ( )
               .ConstructionThrows ( _type ,
                                     _parameterTypes ,
                                     _parameterValues ,
                                     _exceptionType )
               .Should ( )
               .BeFalse ( ) ;
        }

        [ TestInitialize ]
        public void Setup ( )
        {
            _logger = Substitute.For < ILogger > ( ) ;

            _type = typeof ( TestClassWithInterfaceAndGuard ) ;

            _parameterTypes = typeof ( TestClassWithInterfaceAndGuard ).GetConstructors ( )
                                                                       .First ( )
                                                                       .GetParameters ( )
                                                                       .Select ( x => x.ParameterType )
                                                                       .ToArray ( ) ;

            _parameterValues =
            [
                new TestClass ( 0 ) ,
                Substitute.For < ISomething > ( ) ,
                "Text" ,
                0
            ] ;

            _exceptionType = typeof ( ArgumentNullException ) ;
        }

        private InstanceCreator CreateSut ( )
        {
            return new InstanceCreator ( _logger ) ;
        }
    }
}