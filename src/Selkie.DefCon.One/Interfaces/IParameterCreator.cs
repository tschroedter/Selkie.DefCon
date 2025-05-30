using System ;
using System.Reflection ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces ;

/// <summary>
///     Creates dummy parameters for a given type.
/// </summary>
public interface IParameterCreator
{
    /// <summary>
    ///     Returns a collection of dummy parameters which can be used to
    ///     create an instance of the given type.
    /// </summary>
    /// <param name="type">
    ///     The instance type to be created.
    /// </param>
    /// <param name="arrayParameter">
    ///     Information about the required parameters to create the instance.
    /// </param>
    /// <param name="parameterIndex">
    ///     The index of the parameter to have the given parameterValue.
    /// </param>
    /// <param name="parameterValue">
    ///     The value to be used to set at the given parameterIndex.
    /// </param>
    /// <returns>
    ///     An array of parameters.
    /// </returns>
    [ NotNull ]
    object [ ] Create ( [ NotNull ] Type              type ,
                        [ NotNull ] ParameterInfo [ ] arrayParameter ,
                        int                           parameterIndex ,
                        [ CanBeNull ] object          parameterValue ) ;
}