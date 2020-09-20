using System ;
using AutoFixture ;
using AutoFixture.AutoNSubstitute ;
using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using NSubstitute ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.DotNetCore.Tests.Common ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Constructor
{
    [ TestClass ]
    public class NotNullTesterResultTester
    {
        private INotNullTester _notNullTester ;

        [ TestMethod ]
        public void Constructor_ForNotNullTester_SetsConstructorsFailed ( )
        {
            CreateSut ( )
               .Failed.Should ( )
               .Be ( _notNullTester.ConstructorsFailed ) ;
        }

        [ TestMethod ]
        public void Constructor_ForNotNullTester_SetsConstructorsToTest ( )
        {
            CreateSut ( )
               .ToTest.Should ( )
               .Be ( _notNullTester.ConstructorsToTest ) ;
        }

        [ TestMethod ]
        public void Constructor_ForNotNullTester_SetsExceptionType ( )
        {
            CreateSut ( )
               .ExceptionType.Should ( )
               .Be ( _notNullTester.ExceptionType ) ;
        }

        [ TestMethod ]
        public void Constructor_ForNotNullTester_SetsHasPassed ( )
        {
            CreateSut ( )
               .HasPassed.Should ( )
               .Be ( _notNullTester.HasPassed ) ;
        }

        [ TestMethod ]
        public void Constructor_ForNotNullTester_SetsInstanceType ( )
        {
            CreateSut ( )
               .InstanceType.Should ( )
               .Be ( _notNullTester.InstanceType ) ;
        }

        [ TestMethod ]
        public void Constructor_ForNotNullTester_SetsTestValue ( )
        {
            CreateSut ( )
               .TestValue.Should ( )
               .Be ( _notNullTester.TestValue ) ;
        }

        [ TestMethod ]
        public void Constructor_ForNotNullTesterNull_Throws ( )
        {
            _notNullTester = null ;

            var action = new Action ( ( ) => CreateSut ( ) ) ;

            action.Should ( )
                  .Throw < ArgumentNullException > ( )
                  .And.ParamName.Should ( )
                  .Be ( "notNullTester" ) ;
        }

        [ TestInitialize ]
        public void Setup ( )
        {
            _notNullTester = Substitute.For < INotNullTester > ( ) ;

            _notNullTester.HasPassed.Returns ( true ) ;
            _notNullTester.TestValue.Returns ( new object ( ) ) ;
            _notNullTester.ExceptionType.Returns ( typeof ( Exception ) ) ;
            _notNullTester.InstanceType.Returns ( typeof ( TestClass ) ) ;
            _notNullTester.ConstructorsToTest.Returns ( 1 ) ;
            _notNullTester.ConstructorsFailed.Returns ( 2 ) ;
        }

        [ TestMethod ]
        public void Test ( )
        {
            var fixture = new Fixture ( ).Customize ( new AutoNSubstituteCustomization ( ) ) ;

            fixture.Freeze < INotNullTester > ( )
                   .HasPassed.Returns ( true ) ;

            var target = fixture.Create < NotNullTesterResult > ( ) ;

            target.HasPassed.Should ( )
                  .BeTrue ( ) ;
        }

        [ DataTestMethod ]
        [ AutoNSubstituteData ]
        public void Test1 ( Fixture fixture )
        {
            fixture.Freeze < INotNullTester > ( )
                   .HasPassed.Returns ( true ) ;

            var sut = fixture.Create < NotNullTesterResult > ( ) ;

            sut.HasPassed.Should ( )
               .BeTrue ( ) ;
        }

        private NotNullTesterResult CreateSut ( )
        {
            return new NotNullTesterResult ( _notNullTester ) ;
        }
    }
}