using System.Linq ;
using System.Reflection ;

namespace Selkie.DefCon.One.Extensions ;

public static class ParameterInfoExtensions
{
    public static string ToText ( this ParameterInfo info )
    {
        var attributes = info.CustomAttributes
                             .Select ( x => x.AttributeType.FullName ) ;
        var attributesAsText = string.Join ( ", " ,
                                             attributes ) ;

        if ( attributesAsText != string.Empty ) attributesAsText = $"[{attributesAsText}] " ;

        var result = attributesAsText                  +
                     $"{info.ParameterType.FullName} " +
                     $"{info.Name}" ;

        return result ;
    }

    public static string ToText ( this ParameterInfo [ ] info )
    {
        var texts = info.Select ( x => x.ToText ( ) ) ;

        var result = string.Join ( ", " ,
                                   texts ) ;

        return result ;
    }
}