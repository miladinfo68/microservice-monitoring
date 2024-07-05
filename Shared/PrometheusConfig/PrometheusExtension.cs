using Microsoft.AspNetCore.Builder;
using Prometheus;

namespace Shared.PrometheusConfig;

public static class PrometheusExtension
{
    public static IApplicationBuilder UsePrometheusMetrics(
        this IApplicationBuilder app, PrometheusMetricsConfig? configs=default)
    {
        if (configs is not null)
        {
            app.UseMetricServer(configs.Port, configs.Configure, configs.Url);
        }
        else
        {
            app.UseMetricServer();
        }

        app.UseHttpMetrics();

        return app;
    }
}

public class PrometheusMetricsConfig
{
    public int Port { get; set; }
    public string Url { get; set; }
    public Action<MetricServerMiddleware.Settings> Configure { get; set; }
}