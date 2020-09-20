using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces
{
    public interface IPublicClassesFinderToStringConverter
    {
        [ NotNull ]
        string Convert ( [ NotNull ] IPublicClassesFinder finder ) ;
    }
}