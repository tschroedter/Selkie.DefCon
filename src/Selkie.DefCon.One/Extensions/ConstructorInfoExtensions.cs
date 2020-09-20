using System.Reflection ;

namespace Selkie.DefCon.One.Extensions
{
    public static class ConstructorInfoExtensions
    {
        public static string ToText ( this ConstructorInfo info )
        {
            var @static = info.IsStatic
                              ? "static "
                              : string.Empty ;
            var access = info.IsPublic
                             ? "public "
                             : "" ;

            var parametersText = info.GetParameters ( )
                                     .ToText ( ) ;

            var type = info.DeclaringType != null
                           ? info.DeclaringType.Name
                           : "null" ;

            return string.Format ( $"{access}{@static}void {type} ( {parametersText} )" ) ;
        }
    }
}