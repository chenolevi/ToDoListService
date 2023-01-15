using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.SqlServer;
using System.Data.SqlClient;

namespace Hangfire
{
    public static class DIRegistration
    {
        public static IServiceCollection AddHangfire(this IServiceCollection services,
            IConfiguration configuration)
        {
            var hangfireConnectionString = GetHangfireConnectionString(configuration);
            services.AddHangfire(config => config
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(hangfireConnectionString, new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        DisableGlobalLocks = true
                    }));
            services.AddHangfireServer();
            return services;
        }

        private static string GetHangfireConnectionString(IConfiguration configuration)
        {
            var baseConnectionStrings = configuration.GetConnectionString("BaseConnectionStrings");
            var masterConnectionString = string.Format(baseConnectionStrings, "master");
            var hangfireDB = configuration.GetConnectionString("HangfireDB");
            using (var dbContext = new SqlConnection(masterConnectionString))
            {
                dbContext.Open();                
                var sqlCommand = string.Format(
                    @"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}') create database [{0}]", 
                    hangfireDB);
                using var command = new SqlCommand(sqlCommand, dbContext);
                command.ExecuteNonQuery();
            }
            return string.Format(baseConnectionStrings, hangfireDB);
        }
    }
}