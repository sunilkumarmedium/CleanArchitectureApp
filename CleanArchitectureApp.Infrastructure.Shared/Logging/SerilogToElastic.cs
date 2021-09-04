using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
namespace CleanArchitectureApp.Infrastructure.Shared.Logging
{
    public static class SerilogToElastic
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure=>
            (context, configuration)=>{

                var elasticUri= context.Configuration.GetValue<string>("ElasticConfiguration:Uri");

                configuration.Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .WriteTo.Elasticsearch(
                        new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri(elasticUri))
                        {
                            IndexFormat = $"applogs-{context.HostingEnvironment.ApplicationName?.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                            AutoRegisterTemplate = true,
                            NumberOfShards=2,
                            NumberOfReplicas=1
                        })
                        .Enrich.WithProperty("Environment",context.HostingEnvironment.EnvironmentName)
                        .Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
                        .ReadFrom.Configuration(context.Configuration);
            };
    }
}