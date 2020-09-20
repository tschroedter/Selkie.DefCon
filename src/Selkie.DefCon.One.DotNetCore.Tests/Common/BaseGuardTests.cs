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

        private static readonly object Instance = new object ( ) ;
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
            yield return new [ ]
                         {
                             Instance
                         } ;
            yield return new object [ ]
                         {
                             Integer
                         } ;
        }

        public static IEnumerable < object [ ] > NullEmptyOrWhitespace ( )
        {
            yield return new object [ ]
                         {
                             null ,
                             typeof ( ArgumentNullException )
                         } ;
            yield return new object [ ]
                         {
                             Empty ,
                             typeof ( ArgumentException )
                         } ;
            yield return new object [ ]
                         {
                             Whitespace ,
                             typeof ( ArgumentException )
                         } ;
        }

        public static IEnumerable < object [ ] > NullOrEmpty ( )
        {
            yield return new object [ ]
                         {
                             null ,
                             typeof ( ArgumentNullException )
                         } ;
            yield return new object [ ]
                         {
                             Empty ,
                             typeof ( ArgumentException )
                         } ;
        }

        public static IEnumerable < object [ ] > NotNegative ( )
        {
            yield return new object [ ]
                         {
                             - 1 ,
                             typeof ( ArgumentException )
                         } ;
            yield return new object [ ]
                         {
                             - 2 ,
                             typeof ( ArgumentException )
                         } ;
        }
    }
}