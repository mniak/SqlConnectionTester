using Dapper;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlTest
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            var logger = new LoggerConfiguration()
               .MinimumLevel.Verbose()
               .WriteTo.Console(standardErrorFromLevel: LogEventLevel.Error)
               .CreateLogger();

            var settings = new Settings();
            config.Bind(settings);
            settings.ThrowExceptionIfInvalid();

            while (true)
            {
                await PerformAsync(logger, settings.ConnectionString, settings.Query);
                await Task.Delay(settings.Delay);
            }
        }

        private static async Task PerformAsync(Logger logger, string connectionString, string query)
        {
            try
            {
                logger.Debug("Connecting...");
                using var sqlConnection = new SqlConnection(connectionString);

                logger.Debug("Executing SQL query: {Query}", query);
                var result = await sqlConnection.ExecuteScalarAsync<int>(query);
                logger.Information("Query result: {Result}", result);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Could not query database");
            }
        }
    }
}
