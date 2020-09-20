using System.Diagnostics.CodeAnalysis ;
using System.Reflection ;
using Autofac ;
using Module = Autofac.Module ;

namespace Selkie.DefCon.One
{
    [ ExcludeFromCodeCoverage ]
    public class DefConOneModule
        : Module
    {
        protected override void Load ( ContainerBuilder builder )
        {
            var assembly = Assembly.GetAssembly ( typeof ( DefConOneModule ) ) ;

            builder.RegisterAssemblyTypes ( assembly )
                   .AsImplementedInterfaces ( ) ;
        }
    }
}