using System.Diagnostics.CodeAnalysis ;
using Selkie.DefCon.One.Arguments ;
using JetBrains.Annotations ;
using Microsoft.VisualStudio.TestTools.UnitTesting ;

namespace Selkie.DefCon.One.DotNetCore.Tests.Common ;

[ ExcludeFromCodeCoverage ]
[ UsedImplicitly ]
public class AutoNSubstituteDataAttribute ( ) :
    DataRowAttribute ( new ObjectFactory ( ) ) ;
