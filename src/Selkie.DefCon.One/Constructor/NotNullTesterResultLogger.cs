using JetBrains.Annotations ;
using Selkie.DefCon.One.Common ;
using Selkie.DefCon.One.Interfaces ;
using Serilog ;

namespace Selkie.DefCon.One.Constructor
{
    [ UsedImplicitly ]
    public class NotNullTesterResultLogger
        : INotNullTesterResultLogger
    {
        private readonly ILogger _logger ;

        public NotNullTesterResultLogger ( [ NotNull ] ILogger logger )
        {
            Guard.ArgumentNotNull ( logger ,
                                    nameof ( logger ) ) ;

            _logger = logger ;
        }

        public void LogResult ( NotNullTesterResult result )
        {
            Guard.ArgumentNotNull ( result ,
                                    nameof ( result ) ) ;

            LogFinished ( result ) ;
            LogSummary ( result ) ;
            LogPassedOrFailed ( result ) ;
        }

        private string FailMessage ( [ NotNull ] NotNullTesterResult result ,
                                     string                          values )
        {
            return $"[ FAILED ] Tested type '{result.InstanceType}' " +
                   $"for '{result.ExceptionType}' using value '{values}'" ;
        }

        private void LogFinished ( [ NotNull ] NotNullTesterResult result )
        {
            _logger.Information ( $"[ FINISHED ] Testing class '{result.InstanceType}'" ) ;
        }

        private void LogPassedOrFailed ( [ NotNull ] NotNullTesterResult result )
        {
            var values = result.TestValue == null
                             ? "null"
                             : result.TestValue.ToString ( ) ;

            _logger.Information ( result.Failed == 0
                                      ? PassMessage ( result ,
                                                      values )
                                      : FailMessage ( result ,
                                                      values ) ) ;
        }

        private void LogSummary ( [ NotNull ] NotNullTesterResult result )
        {
            var testedCount = result.ToTest ;
            var passedCount = testedCount - result.Failed ;

            _logger.Information ( "[ SUMMARY ] Total Tested/Passed: " +
                                  $"{testedCount}/{passedCount}" ) ;
        }

        private string PassMessage ( NotNullTesterResult result ,
                                     string              values )
        {
            return $"[ PASSED ] Tested type '{result.InstanceType}' " +
                   $"for '{result.ExceptionType}' using value '{values}'" ;
        }
    }
}