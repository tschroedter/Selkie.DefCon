using System ;
using System.Linq ;
using System.Reflection ;
using FluentAssertions ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;
using Selkie.DefCon.One.DotNetCore.Tests.Common ;
using Selkie.DefCon.One.Extensions ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Extensions
{
    [ TestClass ]
    public class ObjectArrayExtensionsTests
    {
        private object [ ]    _objects ;
        private ParameterInfo _parameterInfo ;
        private Type          _typeOne ;
        private Type [ ]      _types ;
        private Type          _typeTwo ;

        [ TestInitialize ]
        public void Setup ( )
        {
            _typeOne = typeof ( TestClass ) ;
            _typeTwo = typeof ( TestClassWithInterface ) ;

            _types = new [ ]
                     {
                         null ,
                         _typeOne ,
                         _typeTwo
                     } ;

            _parameterInfo = typeof ( TestClass ).GetConstructors ( )
                                                 .First ( )
                                                 .GetParameters ( )
                                                 .First ( ) ;

            _objects = new object [ ]
                       {
                           null ,
                           _typeOne ,
                           _typeTwo ,
                           _parameterInfo
                       } ;
        }

        [ TestMethod ]
        public void ToText_ForParameterObjectsArray_String ( )
        {
            var expected = "null, "                                                             +
                           "Selkie.DefCon.One.DotNetCore.Tests.Common.TestClass, "              +
                           "Selkie.DefCon.One.DotNetCore.Tests.Common.TestClassWithInterface, " +
                           "System.Int32" ;

            _objects.ToText ( )
                    .Should ( )
                    .Be ( expected ) ;
        }

        [ TestMethod ]
        public void ToText_ForParameterTypesArray_String ( )
        {
            var expected = "null, "                                                +
                           "Selkie.DefCon.One.DotNetCore.Tests.Common.TestClass, " +
                           "Selkie.DefCon.One.DotNetCore.Tests.Common.TestClassWithInterface" ;

            _types.ToText ( )
                  .Should ( )
                  .Be ( expected ) ;
        }
    }
}