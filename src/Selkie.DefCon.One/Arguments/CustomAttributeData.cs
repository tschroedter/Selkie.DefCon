﻿using System ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces.Arguments ;

namespace Selkie.DefCon.One.Arguments
{
    public class CustomAttributeData : ICustomAttributeData
    {
        private readonly System.Reflection.CustomAttributeData _customAttributeData ;

        public CustomAttributeData (
            [ NotNull ] System.Reflection.CustomAttributeData customAttributeData )
        {
            Guard.ArgumentNotNull ( customAttributeData ,
                                    nameof ( customAttributeData ) ) ;

            _customAttributeData = customAttributeData ;
        }

        public Type AttributeType => _customAttributeData.AttributeType ;
    }
}