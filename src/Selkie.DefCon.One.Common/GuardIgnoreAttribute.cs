using System ;

namespace Selkie.DefCon.One.Common ;

// ReSharper disable once RedundantTypeDeclarationBody
[ AttributeUsage(AttributeTargets.Parameter |
                 AttributeTargets.Property  |
                 AttributeTargets.Field     |
                 AttributeTargets.Method ,
                 Inherited = false) ]
public sealed class GuardIgnoreAttribute : Attribute
{
}
