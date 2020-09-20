using System ;
using System.Linq ;
using System.Reflection ;
using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    [ TestClass ]
    public class CallingInformationTests
    {
        private ConstructorInfo _constructorInfo ;
        private ParameterInfo   _parameterInfo ;

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
        public void Constructor_ForParameterInfoIsNull_Throws ( )
        {
            _parameterInfo = null ;

            Action action = ( ) => CreateSut ( ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "parameterInfo" ) ;
        }

        [ TestMethod ]
        public void Constructor_Invoked_SetsConstructorInfo ( )
        {
            CreateSut ( )
               .ConstructorInfo
               .Should ( )
               .BeSameAs ( _constructorInfo ) ;
        }

        [ TestMethod ]
        public void Constructor_Invoked_SetsParameterInfo ( )
        {
            CreateSut ( )
               .ParameterInfo
               .Should ( )
               .BeSameAs ( _parameterInfo ) ;
        }

        private CallingInformation CreateSut ( )
        {
            return new CallingInformation ( _constructorInfo ,
                                            _parameterInfo ) ;
        }

        [ TestInitialize ]
        public void Setup ( )
        {
            _constructorInfo = typeof ( TestClass ).GetConstructors ( )
                                                   .First ( ) ;

            _parameterInfo = _constructorInfo.GetParameters ( )
                                             .First ( ) ;
        }
    }
}