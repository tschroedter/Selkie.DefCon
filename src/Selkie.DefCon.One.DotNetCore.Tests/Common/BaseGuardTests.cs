using System ;
using System.Collections.Generic ;
using FluentAssertions ;
using FluentAssertions.Execution ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    public class BaseGuardTests
    {
        public const string Empty      = "" ;
        public const string Whitespace = " " ;

        private static readonly object Instance = new ( ) ;
        private static readonly int    Integer  = 1 ;

        public static void AssertException ( Action action ,
                                             Type   type ,
                                             string parameter )
        {
            using ( new AssertionScope ( ) )
            {
                action.Should ( )
                      .Throw < Exception > ( )
                      .And.GetType ( )
                      .Should ( )
                      .Be ( type ) ;

                if ( type == typeof ( ArgumentException ) )
                    action.Should ( )
                          .Throw < ArgumentException > ( )
                          .And.ParamName.Should ( )
                          .Be ( "parameter" ) ;
            }
        }

        public static IEnumerable < object [ ] > InstanceAndInteger ( )
        {
            yield return
            [
                Instance
            ] ;
            yield return
            [
                Integer
            ] ;
        }

        public static IEnumerable < object [ ] > NullEmptyOrWhitespace ( )
        {
            yield return
            [
                null ,
                typeof ( ArgumentNullException )
            ] ;
            yield return
            [
                Empty ,
                typeof ( ArgumentException )
            ] ;
            yield return
            [
                Whitespace ,
                typeof ( ArgumentException )
            ] ;
        }

        public static IEnumerable < object [ ] > NullOrEmpty ( )
        {
            yield return
            [
                null ,
                typeof ( ArgumentNullException )
            ] ;
            yield return
            [
                Empty ,
                typeof ( ArgumentException )
            ] ;
        }

        public static IEnumerable < object [ ] > NotNegative ( )
        {
            yield return
            [
                - 1 ,
                typeof ( ArgumentException )
            ] ;
            yield return
            [
                - 2 ,
                typeof ( ArgumentException )
            ] ;
        }
    }
}