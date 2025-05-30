using System ;
using System.Linq ;
using FluentAssertions ;
using FluentAssertions.Execution ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using NSubstitute ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Constructor ;
using Selkie.DefCon.One.DotNetCore.Tests.Common ;
using Selkie.DefCon.One.Extensions ;
using Serilog ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Constructor
{
    [ TestClass ]
    public class DefConConstructorCallsTests
    {
        private DefConConstructorInfo _infoOne ;
        private DefConConstructorInfo _infoOther ;

        // ReSharper disable once NotAccessedField.Local
        private DefConConstructorInfo _infoThree ;
        private DefConConstructorInfo _infoTwo ;
        private ILogger               _logger ;

        [ TestMethod ]
        public void Add_ForOneFailingCallForOneConstructorInfo_AddsEntryToCreatedList ( )
        {
            DefConConstructorInfo [ ] failed =
            [
                _infoOne
            ] ;

            var key = _infoOne.ConstructorInfo.ToText ( ) ;

            CreateSut ( )
               .Add ( failed ) [ key ]
               .Should ( )
               .BeEquivalentTo ( failed ) ;
        }

        [ TestMethod ]
        public void Add_ForOneFailingCallForOneConstructorInfo_CreatesList ( )
        {
            DefConConstructorInfo [ ] failed =
            [
                _infoOne
            ] ;

            CreateSut ( )
               .Add ( failed )
               .Should ( )
               .HaveCount ( 1 ,
                            "One Entry For ConstructorInfo" ) ;
        }

        [ TestMethod ]
        public void Add_ForTwoDifferentClasses_AddsEntriesToCreatedLists ( )
        {
            DefConConstructorInfo [ ] failed =
            [
                _infoOne ,
                _infoOther
            ] ;

            var actual = CreateSut ( )
               .Add ( failed ) ;

            using ( new AssertionScope ( ) )
            {
                var key = _infoOne.ConstructorInfo.ToText ( ) ;

                actual [ key ]
                   .Should ( )
                   .BeEquivalentTo ( [
                                         _infoOne
                                     ] ) ;

                var keyOther = _infoOther.ConstructorInfo.ToText ( ) ;

                actual [ keyOther ]
                   .Should ( )
                   .BeEquivalentTo ( [
                                         _infoOther
                                     ] ) ;
            }
        }

        [ TestMethod ]
        public void Add_ForTwoDifferentClasses_AddsInfos ( )
        {
            DefConConstructorInfo [ ] failed =
            [
                _infoOne ,
                _infoOther
            ] ;

            CreateSut ( )
               .Add ( failed )
               .Should ( )
               .HaveCount ( failed.Length ,
                            "One Entry For ConstructorInfo" ) ;
        }

        [ TestMethod ]
        public void Add_ForTwoDifferentConstructorInfoInstances_AddsInfos ( )
        {
            DefConConstructorInfo [ ] failed =
            [
                _infoOne ,
                _infoOther
            ] ;

            CreateSut ( )
               .Add ( failed )
               .Should ( )
               .HaveCount ( failed.Length ,
                            "One Entry For ConstructorInfo" ) ;
        }

        [ TestMethod ]
        public void Add_ForTwoFailingCallForConstructorInfo_AddsInfos ( )
        {
            DefConConstructorInfo [ ] failed =
            [
                _infoOne ,
                _infoTwo
            ] ;

            CreateSut ( )
               .Add ( failed )
               .Should ( )
               .HaveCount ( 1 ,
                            "One Entry For ConstructorInfo" ) ;
        }

        [ TestMethod ]
        public void Add_ForTwoFailingCallForOneConstructorInfo_AddsEntriesToCreatedList ( )
        {
            DefConConstructorInfo [ ] failed =
            [
                _infoOne ,
                _infoTwo
            ] ;

            var key = _infoOne.ConstructorInfo.ToText ( ) ;

            CreateSut ( )
               .Add ( failed ) [ key ]
               .Should ( )
               .BeEquivalentTo ( failed ) ;
        }

        [ TestMethod ]
        public void Clear_ForInvoked_EmptyList ( )
        {
            DefConConstructorInfo [ ] failed =
            [
                _infoOne
            ] ;

            CreateSut ( )
               .Add ( failed )
               .Clear ( )
               .Should ( )
               .HaveCount ( 0 ) ;
        }

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
        public void Count_ForInvoked_Zero ( )
        {
            CreateSut ( )
               .Should ( )
               .HaveCount ( 0 ) ;
        }

        [ TestInitialize ]
        public void Setup ( )
        {
            _logger = Substitute.For < ILogger > ( ) ;

            _infoOne   = CreateInfo ( 0 , 0 ) ;
            _infoTwo   = CreateInfo ( 0 , 1 ) ;
            _infoThree = CreateInfo ( 1 , 1 ) ;
            _infoOther = CreateOther ( ) ;
        }

        private DefConConstructorInfo CreateInfo ( int skipConstructor ,
                                                   int parameterIndex )
        {
            var constructorInfo = typeof ( TestClassTwoConstructors ).GetConstructors ( )
                                                                     .Skip ( skipConstructor )
                                                                     .First ( ) ;

            var parameterInfo = constructorInfo.GetParameters ( ) ;


            return new DefConConstructorInfo ( constructorInfo ,
                                               typeof ( TestClassTwoConstructors ) ,
                                               parameterInfo ,
                                               null ,
                                               parameterIndex ,
                                               typeof ( ArgumentNullException ) ) ;
        }

        private DefConConstructorInfo CreateOther ( )
        {
            var constructorInfo = typeof ( TestClass ).GetConstructors ( )
                                                      .First ( ) ;

            var parameterInfo = constructorInfo.GetParameters ( ) ;


            return new DefConConstructorInfo ( constructorInfo ,
                                               typeof ( TestClass ) ,
                                               parameterInfo ,
                                               null ,
                                               0 ,
                                               typeof ( ArgumentNullException ) ) ;
        }

        private FailedConstructorCalls CreateSut ( )
        {
            return new FailedConstructorCalls ( _logger ) ;
        }
    }
}