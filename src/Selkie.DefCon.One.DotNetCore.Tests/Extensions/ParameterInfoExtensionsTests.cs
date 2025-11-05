using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using Selkie.DefCon.One.DotNetCore.Tests.Common ;
using Selkie.DefCon.One.Extensions ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Extensions ;

[ TestClass ]
public class ParameterInfoExtensionsTests
{
    [ TestMethod ]
    public void ToText_ForParameterInfoWithoutAttribute_String ( )
    {
        var expected = "System.Int32 value" ;

        // ReSharper disable once PossibleNullReferenceException
        var parameters = typeof ( TestClass ).GetConstructor ( [
                                                                   typeof ( int )
                                                               ] )! // constructor is known to exist in TestClass
                                             .GetParameters ( )!; // parameters are known to exist

        parameters [ 0 ]
           .ToText ( )
           .Should ( )
           .Be ( expected ) ;
    }

    [ TestMethod ]
    public void ToText_ForParameterInfoWithAttribute_String ( )
    {
        var expected = "[Selkie.DefCon.One.Common.GuardIgnoreAttribute] " +
                       "System.Int32 value, "                             +
                       "[Selkie.DefCon.One.Common.GuardIgnoreAttribute] " +
                       "Selkie.DefCon.One.DotNetCore.Tests.Common.ISomething something" ;

        // ReSharper disable once PossibleNullReferenceException
        var parameters = typeof ( TestClassWithAttribute ).GetConstructor ( [
                                                                                typeof ( int ) ,
                                                                                typeof ( ISomething )
                                                                            ] )! // constructor is known to exist
                                                          .GetParameters ( )!; // parameters are known to exist


        parameters
           .ToText ( )
           .Should ( )
           .Be ( expected ) ;
    }

    [ TestMethod ]
    public void ToText_ForParameterInfoArrayWithoutAttribute_String ( )
    {
        var expected = "System.Int32 value" ;

        // ReSharper disable once PossibleNullReferenceException
        var parameters = typeof ( TestClass ).GetConstructor ( [
                                                                   typeof ( int )
                                                               ] )! // constructor is known to exist
                                             .GetParameters ( )!; // parameters are known to exist

        parameters.ToText ( )
                  .Should ( )
                  .Be ( expected ) ;
    }

    [ TestMethod ]
    public void ToText_ForParameterInfoArrayWithAttribute_String ( )
    {
        var expected = "[Selkie.DefCon.One.Common.GuardIgnoreAttribute] " +
                       "System.Int32 value, "                             +
                       "[Selkie.DefCon.One.Common.GuardIgnoreAttribute] " +
                       "Selkie.DefCon.One.DotNetCore.Tests.Common.ISomething something" ;

        // ReSharper disable once PossibleNullReferenceException
        var parameters = typeof ( TestClassWithAttribute ).GetConstructor ( [
                                                                                typeof ( int ) ,
                                                                                typeof ( ISomething )
                                                                            ] )! // constructor is known to exist
                                                          .GetParameters ( )!; // parameters are known to exist

        parameters.ToText ( )
                  .Should ( )
                  .Be ( expected ) ;
    }
}
