using System ;
using System.Linq ;
using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Extensions ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.Constructor ;

[ UsedImplicitly ]
public class NotNullTester
    : INotNullTester
{
    private readonly IFailedConstructorCalls _failedCalls ;

    private readonly ILogger                     _logger ;
    private readonly ICallingInformationProvider _provider ;
    private readonly INotNullTesterResultLogger  _resultLogger ;
    private readonly IConstructorInfoTester      _tester ;

    public NotNullTester ( [ NotNull ] ILogger                     logger ,
                           [ NotNull ] ICallingInformationProvider provider ,
                           [ NotNull ] IConstructorInfoTester      tester ,
                           [ NotNull ] IFailedConstructorCalls     failedCalls ,
                           [ NotNull ] INotNullTesterResultLogger  resultLogger )
    {
        Guard.ArgumentNotNull ( logger ,
                                nameof ( logger ) ) ;
        Guard.ArgumentNotNull ( provider ,
                                nameof ( provider ) ) ;
        Guard.ArgumentNotNull ( tester ,
                                nameof ( tester ) ) ;
        Guard.ArgumentNotNull ( failedCalls ,
                                nameof ( failedCalls ) ) ;
        Guard.ArgumentNotNull ( resultLogger ,
                                nameof ( resultLogger ) ) ;

        _logger       = logger ;
        _provider     = provider ;
        _tester       = tester ;
        _failedCalls  = failedCalls ;
        _resultLogger = resultLogger ;
    }

    public bool HasPassed => ! _failedCalls.Any ( ) ;

    public object TestValue     { get ; } = null ;
    public Type   ExceptionType { get ; } = typeof ( ArgumentNullException ) ;
    public Type   InstanceType  => _provider.InstanceType ;

    public int ConstructorsToTest => _provider.ConstructorsToTest ;

    public int ConstructorsFailed => _failedCalls.Count ;

    public INotNullTester Test ( Type instanceType )
    {
        _logger.Information ( $"[START] Testing class '{instanceType.FullName}'" ) ;

        FindConstructorWithAttribute ( instanceType ) ;

        TestConstructorWithAttribute ( instanceType ) ;

        _resultLogger.LogResult ( new NotNullTesterResult ( this ) ) ;

        return this ;
    }

    public INotNullTester Test < T > ( )
        where T : class
    {
        var instanceType = typeof ( T ) ;

        _logger.Information ( $"[START] Testing class '{instanceType.FullName}'" ) ;

        FindConstructorWithAttribute ( instanceType ) ;

        TestConstructorWithAttribute ( instanceType ) ;

        _resultLogger.LogResult ( new NotNullTesterResult ( this ) ) ;

        return this ;
    }

    private void FindConstructorWithAttribute ( Type instanceType )
    {
        _provider.SetType ( instanceType ) ;
        _provider.Find ( ) ;
    }

    private void TestConstructorWithAttribute ( Type instanceType )
    {
        foreach ( var info in _provider )
        {
            _logger.Information ( $"Constructor '{info.ConstructorInfo.ToText ( )}'" ) ;
            _logger.Information ( $"ParameterInfo '{info.ParameterInfo.ToText ( )}'" ) ;

            _tester.Test ( instanceType ,
                           info.ConstructorInfo ,
                           TestValue ,
                           ExceptionType ) ;

            if ( _tester.HasPassed ) continue ;

            _failedCalls.Add ( _tester.Failed ) ;
        }
    }
}