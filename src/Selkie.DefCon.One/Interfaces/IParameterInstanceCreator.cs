using System ;
using System.Reflection ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces ;

/// <summary>
///     Creates dummy parameter.
/// </summary>
public interface IParameterInstanceCreator
{
    /// <summary>
    ///     Creates a dummy instance for the given parameter type.
    /// </summary>
    /// <param name="parameterType">
    ///     The parameter type to be created.
    /// </param>
    /// <returns>
    ///     An instance of the given parameter type.
    /// </returns>
    [ NotNull ]
    [ UsedImplicitly ]
    object Create ( [ NotNull ] Type parameterType ) ;

    /// <summary>
    ///     Creates a dummy instance for the given parameter info.
    /// </summary>
    /// <param name="parameterInfo">
    ///     The parameter info specifying the type to be created.
    /// </param>
    /// <returns>
    ///     An instance of the given parameter info type.
    /// </returns>
    [ NotNull ]
    [ UsedImplicitly ]
    object Create ( [ NotNull ] ParameterInfo parameterInfo ) ;

    /// <summary>
    ///     Creates dummy parameters for the given parameter array.
    /// </summary>
    /// <param name="arrayParameter">
    ///     ParameterInfos used to create dummy parameters.
    /// </param>
    /// <returns>
    ///     Array of dummy parameters matching the type given in the
    ///     ParameterInfos.
    /// </returns>
    [ NotNull ]
    [ UsedImplicitly ]
    object [ ] Create ( ParameterInfo [ ] arrayParameter ) ;
}