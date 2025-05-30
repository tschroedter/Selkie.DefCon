using System.Text ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;

namespace Selkie.DefCon.One.Constructor ;

public class PublicClassesFinderToStringConverter
    : IPublicClassesFinderToStringConverter
{
    private readonly StringBuilder _builder = new ( ) ;

    public string Convert ( IPublicClassesFinder finder )
    {
        Guard.ArgumentNotNull ( finder ,
                                nameof ( finder ) ) ;

        _builder.Clear ( ) ;

        AddTitle ( finder ) ;

        AddIgnoredTypes ( finder ) ;

        AddDefinedTypes ( finder ) ;

        return _builder.ToString ( ) ;
    }

    private void AddDefinedTypes ( [ NotNull ] IPublicClassesFinder finder )
    {
        _builder.AppendLine ( $"{finder.AllDefinedTypes.Length} Testable InstanceType(s):" ) ;

        for ( var i = 0 ; i < finder.DefinedTypes.Length ; i ++ )
        {
            _builder.AppendLine ( $"[{i}] '{finder.DefinedTypes [ i ].FullName}'" ) ;
        }
    }

    private void AddIgnoredTypes ( [ NotNull ] IPublicClassesFinder finder )
    {
        _builder.AppendLine ( $"{finder.IgnoredTypes.Length} Ignored InstanceType(s):" ) ;

        for ( var i = 0 ; i < finder.IgnoredTypes.Length ; i ++ )
        {
            _builder.AppendLine ( $"[{i}] '{finder.IgnoredTypes [ i ].FullName}'" ) ;
        }
    }

    private void AddTitle ( [ NotNull ] IPublicClassesFinder finder )
    {
        _builder.AppendLine ( $"Found {finder.AllDefinedTypes.Length} types in " +
                              $"assembly '{finder.DefinedAssembly.FullName}':" ) ;
    }
}