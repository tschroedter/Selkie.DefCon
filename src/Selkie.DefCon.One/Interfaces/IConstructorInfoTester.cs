using System ;
using System.Collections.Generic ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;

namespace Selkie.DefCon.One.Interfaces
{
    public interface IConstructorInfoTester
    {
        [ UsedImplicitly ] IEnumerable < DefConConstructorInfo > Failed { get ; }

        [ UsedImplicitly ] bool HasPassed { get ; }

        [ UsedImplicitly ] IEnumerable < DefConConstructorInfo > Ignored { get ; }

        void Test ( [ NotNull ]   Type            instanceType ,
                    [ NotNull ]   ConstructorInfo info ,
                    [ CanBeNull ] object          value ,
                    [ NotNull ]   Type            exceptionType ) ;
    }
}