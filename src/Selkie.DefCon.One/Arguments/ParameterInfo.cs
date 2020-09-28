﻿using System ;
using System.Collections.Generic ;
using System.Linq ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces.Arguments ;

namespace Selkie.DefCon.One.Arguments
{
    public class ParameterInfo : IParameterInfo
    {
        private readonly System.Reflection.ParameterInfo _parameterInfo ;

        public ParameterInfo ( [ NotNull ] System.Reflection.ParameterInfo parameterInfo )
        {
            Guard.ArgumentNotNull ( parameterInfo ,
                                    nameof ( parameterInfo ) ) ;

            _parameterInfo = parameterInfo ;
        }

        public IEnumerable < ICustomAttributeData > CustomAttributes =>
            _parameterInfo.CustomAttributes.Select ( x => new CustomAttributeData ( x ) ) ;

        public Type ParameterType => _parameterInfo.ParameterType ;
    }
}