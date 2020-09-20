using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Reflection ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Extensions ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.Constructor
{
    [ UsedImplicitly ] // todo missing tests?
    public class ConstructorInfoTester
        : IConstructorInfoTester
    {
        private readonly List < DefConConstructorInfo > _failed  = new List < DefConConstructorInfo > ( ) ;
        private readonly List < DefConConstructorInfo > _ignored = new List < DefConConstructorInfo > ( ) ;

        [ NotNull ] private readonly ILogger _logger ;

        [ NotNull ] private readonly ISingleParameterTester _tester ;

        public ConstructorInfoTester ( [ NotNull ] ILogger                logger ,
                                       [ NotNull ] ISingleParameterTester tester )
        {
            Guard.ArgumentNotNull ( tester ,
                                    nameof ( tester ) ) ;
            Guard.ArgumentNotNull ( logger ,
                                    nameof ( logger ) ) ;

            _logger = logger ;
            _tester = tester ;
        }

        public IEnumerable < DefConConstructorInfo > Ignored => _ignored ; // todo testing

        public IEnumerable < DefConConstructorInfo > Failed => _failed ;

        public bool HasPassed => ! Failed.Any ( ) ;

        public void Test ( Type            instanceType ,
                           ConstructorInfo info ,
                           object          value ,
                           Type            exceptionType )
        {
            _logger.Information ( $"[ TEST ] {info.ToText ( )}" ) ;

            _failed.Clear ( ) ;

            var arrayParameter = info.GetParameters ( ) ;

            for ( var index = 0 ; index < arrayParameter.Length ; index ++ )
            {
                var parameterInfo = arrayParameter [ index ] ;

                if ( value                       != null &&
                     parameterInfo.ParameterType != value.GetType ( ) )
                    continue ;

                if ( ! ( parameterInfo.ParameterType.IsClass ||
                         parameterInfo.ParameterType.IsInterface ) )
                    continue ;

                if ( parameterInfo.CustomAttributes.Any ( IsParameterIgnored ) )
                {   // todo logging ignore parameter and separate GuardIgnored attribute from test nuget package
                    IgnoreSingleParameter ( instanceType ,
                                            info ,
                                            arrayParameter ,
                                            index ,
                                            value ,
                                            exceptionType ) ;
                    continue ;
                }

                TestSingleParameter ( instanceType ,
                                      info ,
                                      arrayParameter ,
                                      index ,
                                      value ,
                                      exceptionType ) ;
            }
        }

        private void IgnoreSingleParameter ( Type              instanceType ,
                                             ConstructorInfo   info ,
                                             ParameterInfo [ ] arrayParameter ,
                                             in int            index ,
                                             object            value ,
                                             Type              exceptionType )
        {
            var ignored = new DefConConstructorInfo ( info ,
                                                      instanceType ,
                                                      arrayParameter ,
                                                      value ,
                                                      index ,
                                                      exceptionType ) ;

            _ignored.Add ( ignored ) ;
        }

        private bool IsParameterIgnored ( CustomAttributeData data )
        {
            return data.AttributeType == typeof ( GuardIgnoreAttribute ) ;
        }

        private void TestSingleParameter ( Type              instanceType ,
                                           ConstructorInfo   info ,
                                           ParameterInfo [ ] arrayParameter ,
                                           int               index ,
                                           object            value ,
                                           Type              exceptionType )
        {
            var hasPassed = _tester.Test ( info ,
                                           instanceType ,
                                           arrayParameter ,
                                           value ,
                                           exceptionType ,
                                           index ) ;

            if ( hasPassed ) return ;

            var failed = new DefConConstructorInfo ( info ,
                                                     instanceType ,
                                                     arrayParameter ,
                                                     value ,
                                                     index ,
                                                     exceptionType ) ;

            _failed.Add ( failed ) ;
        }
    }
}