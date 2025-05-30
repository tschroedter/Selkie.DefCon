using Serilog ;
using Serilog.Configuration ;

namespace Selkie.DefCon.One.Common ;

public static class LoggerCallerEnrichmentConfiguration
{
    public static LoggerConfiguration WithCaller ( this LoggerEnrichmentConfiguration enrichmentConfiguration )
    {
        return enrichmentConfiguration.With < CallerEnricher > ( ) ;
    }
}