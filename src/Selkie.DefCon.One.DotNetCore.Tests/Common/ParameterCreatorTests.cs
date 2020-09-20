using System ;
using System.Linq ;
using System.Reflection ;
using FluentAssertions ;
using FluentAssertions.Execution ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using NSubstitute ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    [ TestClass ]
    public class ParameterCreatorTests
    {
        private ParameterInfo [ ]         _arrayParameter ;
        private object [ ]                _createdParameters ;
        private IParameterInstanceCreator _creator ;
        private int                       _parameterIndex ;
        private object                    _parameterValue ;
        private Type                      _type ;

        [ TestMethod ]
        public void Constructor_ForIParameterInstanceCreatorIsNull_Throws ( )
        {
            _creator = null ;

            Action action = ( ) => CreateSut ( ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "creator" ) ;
        }

        [ TestMethod ]
        public void Create_ForArrayParameterIsNull_Throws ( )
        {
            _arrayParameter = null ;

            Action action = ( ) => CreateSut ( )
                               .Create ( _type ,
                                         _arrayParameter ,
                                         _parameterIndex ,
                                         _parameterValue ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "arrayParameter" ) ;
        }

        [ TestMethod ]
        public void Create_ForCorrectParameters_ReturnsParameters ( )
        {
            var actual = CreateSut ( )
               .Create ( _type ,
                         _arrayParameter ,
                         _parameterIndex ,
                         _parameterValue ) ;

            using ( new AssertionScope ( ) )
            {
                actual
                   .Length
                   .Should ( )
                   .Be ( _createdParameters.Length ,
                         "Length" ) ;

                actual [ 0 ]
                   .Should ( )
                   .BeNull ( "[0] Should be null" ) ;

                actual [ 1 ]
                   .Should ( )
                   .Be ( _createdParameters [ 1 ] ,
                         "[1] Should have dummy value" ) ;

                actual [ 2 ]
                   .Should ( )
                   .Be ( _createdParameters [ 2 ] ,
                         "[2] Should have dummy value" ) ;
            }
        }

        [ TestMethod ]
        public void Create_ForParameterIndexIsNegative_Throws ( )
        {
            _parameterIndex = - 1 ;

            Action action = ( ) => CreateSut ( )
                               .Create ( _type ,
                                         _arrayParameter ,
                                         _parameterIndex ,
                                         _parameterValue ) ;

            action.Should ( )
                  .Throw < ArgumentException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "parameterIndex" ) ;
        }

        [ TestMethod ]
        public void Create_ForParameterIndexIsToBig_Throws ( )
        {
            _parameterIndex = - 1 ;

            Action action = ( ) => CreateSut ( )
                               .Create ( _type ,
                                         _arrayParameter ,
                                         _arrayParameter.Length ,
                                         _parameterValue ) ;

            action.Should ( )
                  .Throw < ArgumentException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "parameterIndex" ) ;
        }

        [ TestMethod ]
        public void Create_ForTypeIsNull_Throws ( )
        {
            _type = null ;

            Action action = ( ) => CreateSut ( )
                               .Create ( _type ,
                                         _arrayParameter ,
                                         _parameterIndex ,
                                         _parameterValue ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "type" ) ;
        }

        [ TestInitialize ]
        public void Setup ( )
        {
            _creator = Substitute.For < IParameterInstanceCreator > ( ) ;

            _type = typeof ( TestClassWithInterface ) ;
            _arrayParameter = typeof ( TestClassWithInterface ).GetConstructors ( )
                                                               .First ( )
                                                               .GetParameters ( ) ;
            _parameterIndex = 0 ;
            _parameterValue = null ;

            _createdParameters = new object [ ]
                                 {
                                     new TestClass ( 0 ) ,
                                     Substitute.For < ISomething > ( ) ,
                                     "Text" ,
                                     0
                                 } ;

            _creator.Create ( Arg.Any < ParameterInfo [ ] > ( ) )
                    .Returns ( _createdParameters ) ;
        }

        private ParameterCreator CreateSut ( )
        {
            return new ParameterCreator ( _creator ) ;
        }
    }
}