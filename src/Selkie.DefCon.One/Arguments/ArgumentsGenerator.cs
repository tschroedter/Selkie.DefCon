﻿using System ;
using System.Collections.Generic ;
using System.Globalization ;
using System.Linq ;
using AutoFixture ;
using AutoFixture.AutoNSubstitute ;
using AutoFixture.Kernel ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces.Arguments ;

namespace Selkie.DefCon.One.Arguments ;

// todo this folder contains classes which are the same as Selkie.AutoMocking
// todo extract this folder into separate NuGet package
[ UsedImplicitly ]
public class ArgumentsGenerator : IArgumentsGenerator
{
    private readonly IFixture    _fixture ;
    private readonly ISutCreator _sutCreator ;

    public ArgumentsGenerator ( )
        : this ( new Fixture ( ) ,
                 new SutCreator ( new SutInstanceCreator ( new ArgumentNullExceptionFinder ( ) ) ,
                                  new SutLazyInstanceCreator ( new ArgumentNullExceptionFinder ( ) ) ) )
    {
    }

    internal ArgumentsGenerator ( [ NotNull ] IFixture    fixture ,
                                  [ NotNull ] ISutCreator sutCreator )
    {
        Guard.ArgumentNotNull ( fixture ,
                                nameof ( fixture ) ) ;
        Guard.ArgumentNotNull ( sutCreator ,
                                nameof ( sutCreator ) ) ;

        _fixture    = fixture ;
        _sutCreator = sutCreator ;

        _fixture.Customize ( new AutoNSubstituteCustomization
                             {
                                 ConfigureMembers = true
                             } ) ;
    }

    public object [ ] Create ( IEnumerable < IParameterInfo > parameterInfos )
    {
        Guard.ArgumentNotNull ( parameterInfos ,
                                nameof ( parameterInfos ) ) ;

        var infos = parameterInfos as IParameterInfo [ ] ?? parameterInfos.ToArray ( ) ;

        return infos.Length == 0
                   ? []
                   : CreateArguments ( infos ) ;
    }

    public object CreateArgument ( [ NotNull ] Type type ,
                                   bool             isFreeze = false ,
                                   bool             isBeNull = false )
    {
        Guard.ArgumentNotNull ( type ,
                                nameof ( type ) ) ;

        if ( isFreeze ) _fixture.Customize ( new FreezingCustomization ( type ) ) ;

        if ( isBeNull ) _fixture.Customize ( new BeNullCustomization ( type ) ) ;

        object parameter = null ;

        try
        {
            parameter = _fixture.Create ( type ,
                                          new SpecimenContext ( _fixture ) ) ;
        }
        catch ( Exception e )
        {
            Console.WriteLine ( e ) ;
        }

        if ( parameter != null ||
             isBeNull )
            return parameter ;

        var message = string.Format ( CultureInfo.InvariantCulture ,
                                      $"Failed to create type '{type.FullName}'" ) ;

        throw new ArgumentNullException ( type.FullName ,
                                          message ) ;
    }

    private static bool IsFreezeParameter ( IParameterInfo info )
    {
        return info.CustomAttributes.Any ( x => x.AttributeType == typeof ( FreezeAttribute ) ) ;
    }

    private static bool IsBeNullParameter ( IParameterInfo info )
    {
        return info.CustomAttributes.Any ( x => x.AttributeType == typeof ( BeNullAttribute ) ) ;
    }

    private object [ ] CreateArguments ( IParameterInfo [ ] infos )
    {
        var parameters = CreateOtherArguments ( infos ) ;

        parameters [ 0 ] = _sutCreator.Construct ( this ,
                                                   infos [ 0 ].ParameterType ) ;

        return parameters ;
    }

    private object [ ] CreateOtherArguments ( IParameterInfo [ ] infos )
    {
        var parameters = new object[ infos.Length ] ;

        for ( var i = 1 ; i < infos.Length ; i ++ )
        {
            var info = infos [ i ] ;

            parameters [ i ] = CreateArgument ( info.ParameterType ,
                                                IsFreezeParameter ( info ) ,
                                                IsBeNullParameter ( info ) ) ;
        }

        return parameters ;
    }
}