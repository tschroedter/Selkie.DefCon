using System ;
using System.Reflection ;
using JetBrains.Annotations ;

namespace Selkie.DefCon.One.Common
{
    public readonly struct DefConConstructorInfo
    {
        public DefConConstructorInfo ( [ NotNull ]   ConstructorInfo   constructorInfo ,
                                       [ NotNull ]   Type              instanceType ,
                                       [ NotNull ]   ParameterInfo [ ] parameterInfoArray ,
                                       [ CanBeNull ] object            testParameterValue ,
                                       int                             testParameterIndex ,
                                       Type                            exceptionType )
        {
            Guard.ArgumentNotNull ( parameterInfoArray ,
                                    nameof ( parameterInfoArray ) ) ;
            Guard.ArgumentNotNull ( instanceType ,
                                    nameof ( instanceType ) ) ;
            Guard.ArgumentNotNull ( constructorInfo ,
                                    nameof ( constructorInfo ) ) ;
            Guard.ArgumentBetween ( testParameterIndex ,
                                    nameof ( testParameterIndex ) ,
                                    0 ,
                                    parameterInfoArray.Length ) ;

            ConstructorInfo    = constructorInfo ;
            InstanceType       = instanceType ;
            TestParameterIndex = testParameterIndex ;
            ExceptionType      = exceptionType ;
            ParameterInfoArray = parameterInfoArray ;
            TestParameterValue = testParameterValue ;
        }

        public ConstructorInfo   ConstructorInfo    { get ; }
        public Type              InstanceType       { get ; }
        public int               TestParameterIndex { get ; }
        public Type              ExceptionType      { get ; }
        public ParameterInfo [ ] ParameterInfoArray { get ; }
        public object            TestParameterValue { get ; }

        // todo ToString
    }
}