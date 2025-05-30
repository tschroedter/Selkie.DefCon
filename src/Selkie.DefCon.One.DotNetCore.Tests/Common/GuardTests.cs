using System ;
using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common ;

[ TestClass ]
public class GuardTests : BaseGuardTests
{
    [ DataTestMethod ]
    [ DynamicData ( nameof ( NullEmptyOrWhitespace ) ,
                    typeof ( BaseGuardTests ) ,
                    DynamicDataSourceType.Method ) ]
    public void ArgumentNotEmptyOrWhitespace_ForInvalidValues_Throws ( string value ,
                                                                       Type   type )
    {
        AssertException ( ( ) => Guard.ArgumentNotEmptyOrWhitespace ( value ,
                                                                      "parameter" ) ,
                          type ,
                          "parameter" ) ;
    }

    [ DataTestMethod ]
    [ DynamicData ( nameof ( InstanceAndInteger ) ,
                    typeof ( BaseGuardTests ) ,
                    DynamicDataSourceType.Method ) ]
    public void ArgumentNotEmptyOrWhitespace_ForValues_DoesNotThrows ( object value )
    {
        var action = new Action ( ( ) => Guard.ArgumentNotEmptyOrWhitespace ( value ,
                                                                              "parameter" ) ) ;

        action.Should ( )
              .NotThrow ( ) ;
    }

    [ DataTestMethod ]
    [ DynamicData ( nameof ( NotNegative ) ,
                    typeof ( BaseGuardTests ) ,
                    DynamicDataSourceType.Method ) ]
    public void ArgumentNotNegative_ForValues_Throws ( int  value ,
                                                       Type type )
    {
        AssertException ( ( ) => Guard.ArgumentNotNegative ( value ,
                                                             "parameter" ) ,
                          type ,
                          "parameter" ) ;
    }

    [ DataTestMethod ]
    [ DataRow ( 0 ) ]
    [ DataRow ( 1 ) ]
    [ DataRow ( 2 ) ]
    public void ArgumentNotNegative_ForZeroAndPositiveValues_DoesNotThrow ( int value )
    {
        var action = new Action ( ( ) => Guard.ArgumentNotNegative ( value ,
                                                                     "parameter" ) ) ;

        action.Should ( )
              .NotThrow ( ) ;
    }

    [ DataTestMethod ]
    [ DynamicData ( nameof ( InstanceAndInteger ) ,
                    typeof ( BaseGuardTests ) ,
                    DynamicDataSourceType.Method ) ]
    public void ArgumentNotNull_ForValueNotNull_DoesNotThrows ( object value )
    {
        var action = new Action ( ( ) => Guard.ArgumentNotNull ( value ,
                                                                 "parameter" ) ) ;

        action.Should ( )
              .NotThrow ( ) ;
    }

    [ TestMethod ]
    public void ArgumentNotNull_ForValueNull_Throws ( )
    {
        // ReSharper disable once AssignNullToNotNullAttribute
        var action = new Action ( ( ) => Guard.ArgumentNotNull ( null ,
                                                                 "parameter" ) ) ;

        action.Should ( )
              .Throw < ArgumentNullException > ( )
              .And.ParamName.Should ( )
              .Be ( "parameter" ) ;
    }

    [ DataTestMethod ]
    [ DynamicData ( nameof ( InstanceAndInteger ) ,
                    typeof ( BaseGuardTests ) ,
                    DynamicDataSourceType.Method ) ]
    public void ArgumentNotNullOrEmpty_ForValues_DoesNotThrows ( object value )
    {
        var action = new Action ( ( ) => Guard.ArgumentNotNullOrEmpty ( value ,
                                                                        "parameter" ) ) ;

        action.Should ( )
              .NotThrow ( ) ;
    }

    [ DataTestMethod ]
    [ DynamicData ( nameof ( NullOrEmpty ) ,
                    typeof ( BaseGuardTests ) ,
                    DynamicDataSourceType.Method ) ]
    public void ArgumentNotNullOrEmpty_ForValues_Throws ( string value ,
                                                          Type   type )
    {
        AssertException ( ( ) => Guard.ArgumentNotNullOrEmpty ( value ,
                                                                "parameter" ) ,
                          type ,
                          "parameter" ) ;
    }
}