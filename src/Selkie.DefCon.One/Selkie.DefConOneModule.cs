using System ;
using System.Diagnostics.CodeAnalysis ;
using System.Reflection ;
using Autofac ;
using Module = Autofac.Module ;

namespace Selkie.DefCon.One ;

[ ExcludeFromCodeCoverage ]
public class DefConOneModule
    : Module
{
    protected override void Load ( ContainerBuilder builder )
    {
        var type = typeof ( DefConOneModule ) ;

        var assembly = Assembly.GetAssembly ( type ) ;

        if ( assembly == null )
            throw new Exception ( $"Failed to get assembly for {type.FullName}" ) ;

        builder.RegisterAssemblyTypes ( assembly )
               .AsImplementedInterfaces ( ) ;
    }
}