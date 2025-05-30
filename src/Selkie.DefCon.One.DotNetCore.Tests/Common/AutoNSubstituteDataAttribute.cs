using System.Diagnostics.CodeAnalysis ;
using AutoFixture ;
using AutoFixture.AutoNSubstitute ;
using JetBrains.Annotations ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common
{
    [ ExcludeFromCodeCoverage ]
    [ UsedImplicitly ]
    public class AutoNSubstituteDataAttribute ( ) : 
        DataRowAttribute ( new Fixture ( ).Customize ( new AutoNSubstituteCustomization ( ) ) ) ;
}