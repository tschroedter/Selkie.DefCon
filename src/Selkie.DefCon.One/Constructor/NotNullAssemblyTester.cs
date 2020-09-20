using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.Constructor
{
    [ UsedImplicitly ]
    public class NotNullAssemblyTester
        : INotNullAssemblyTester
    {
        private readonly IPublicClassesFinder _finder ;
        private readonly INotNullTester       _tester ;

        public NotNullAssemblyTester ( [ NotNull ] IPublicClassesFinder finder ,
                                       [ NotNull ] INotNullTester       tester )
        {
            Guard.ArgumentNotNull ( finder ,
                                    nameof ( finder ) ) ;
            Guard.ArgumentNotNull ( tester ,
                                    nameof ( tester ) ) ;

            _finder = finder ;
            _tester = tester ;
        }

        public void Test ( Assembly assembly )
        {
            Guard.ArgumentNotNull ( assembly ,
                                    nameof ( assembly ) ) ;

            _finder.LoadTypes ( assembly ) ;

            foreach ( var definedType in _finder.DefinedTypes )
            {
                _tester.Test ( definedType ) ;
            }
        }
    }
}