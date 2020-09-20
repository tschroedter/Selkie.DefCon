using System.Reflection ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Common
{
    /// <summary>
    ///     Contains all the information required to create a new instance.
    /// </summary>
    public readonly struct CallingInformation
    {
        /// <inheritdoc cref="System.Reflection.ConstructorInfo" />
        public ConstructorInfo ConstructorInfo { get ; }

        /// <inheritdoc cref="System.Reflection.ParameterInfo" />
        public ParameterInfo ParameterInfo { get ; }

        /// <summary>
        ///     Store information to generate a new instance.
        /// </summary>
        /// <param name="constructorInfo">
        ///     The <see cref="System.Reflection.ConstructorInfo" />
        /// </param>
        /// <param name="parameterInfo">
        ///     The <see cref="System.Reflection.ParameterInfo" />
        /// </param>
        public CallingInformation ( [ NotNull ] ConstructorInfo constructorInfo ,
                                    [ NotNull ] ParameterInfo   parameterInfo )
        {
            Guard.ArgumentNotNull ( constructorInfo ,
                                    nameof ( constructorInfo ) ) ;
            Guard.ArgumentNotNull ( parameterInfo ,
                                    nameof ( parameterInfo ) ) ;

            ConstructorInfo = constructorInfo ;
            ParameterInfo   = parameterInfo ;
        }
    }
}