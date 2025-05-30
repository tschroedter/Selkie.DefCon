﻿using System ;
using System.Collections.Generic ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Interfaces.Arguments ;

public interface IArgumentsGenerator
{
    [ NotNull ]
    object [ ] Create ( [ NotNull ] IEnumerable < IParameterInfo > parameterInfos ) ;

    object CreateArgument ( Type type ,
                            bool isFreeze = false ,
                            bool isBeNull = false ) ;
}