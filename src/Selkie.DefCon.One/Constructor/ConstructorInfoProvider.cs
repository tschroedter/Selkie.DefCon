using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.Constructor ;

[ UsedImplicitly ]
public class ConstructorInfoProvider
    : IConstructorInfoProvider
{
    private static readonly ConstructorInfo [ ] Empty = [] ;

    private readonly ILogger _logger ;

    private ConstructorInfo [ ] _constructors = Empty ;

    public ConstructorInfoProvider ( [ NotNull ] ILogger logger )
    {
        Guard.ArgumentNotNull ( logger ,
                                nameof ( logger ) ) ;

        _logger = logger ;
    }

    public int Length => _constructors.Length ;
    public ConstructorInfo this [ int index ] => _constructors [ index ] ;

    public Type Type { get ; private set ; } = typeof ( object ) ;

    public IConstructorInfoProvider SetType ( Type type )
    {
        Guard.ArgumentNotNull ( type ,
                                nameof ( type ) ) ;

        Type = type ;

        _constructors = Type.GetConstructors ( )
                            .ToArray ( ) ;

        _logger.Information ( $"Loaded constructors for type '{Type}'" ) ;

        return this ;
    }

    public IEnumerator < ConstructorInfo > GetEnumerator ( )
    {
        return ( ( IEnumerable < ConstructorInfo > ) _constructors ).GetEnumerator ( ) ;
    }

    IEnumerator IEnumerable.GetEnumerator ( )
    {
        return GetEnumerator ( ) ;
    }
}