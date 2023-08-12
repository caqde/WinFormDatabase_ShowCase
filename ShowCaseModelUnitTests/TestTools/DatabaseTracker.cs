using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ShowCaseModelUnitTests.TestTools
{
    public static class DatabaseTracker
    {
        private static DbContextOptionsBuilder<ShowCaseDbContext> builder;
        private static ChangeTracking changeTracker;
        private static bool previousTestRequireFullReset = false;

        static DatabaseTracker()
        {
            SetupOptions();
        }

        public static void SetupOptions()
        {
            changeTracker = new ChangeTracking();
            builder = new DbContextOptionsBuilder<ShowCaseDbContext>();
            var configbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configbuilder.Build();
            var connectionString = configuration.GetConnectionString("TestShowCaseDB");
            builder.UseNpgsql(connectionString, options => options.EnableRetryOnFailure())
                .AddInterceptors(changeTracker);
        }

        public static DbContextOptionsBuilder<ShowCaseDbContext> GetOptionBuilder()
        {
            return builder;
        }

        public static void New(bool requireFullReset = false)
        {
            if (previousTestRequireFullReset)
            {
                using var db = new ShowCaseDbContext(builder.Options);
                var sql = File.ReadAllText("cleardb.sql");
                db.Database.ExecuteSqlRaw(sql);
                db.Dispose();
            }
            else
            {
                using var db = new ShowCaseDbContext(builder.Options);
                var tableNames = changeTracker.GetAffectedTables();
                var sql = File.ReadAllText("cleardbpartial.sql");
                if (tableNames != null && tableNames.Count >= 1)
                {
                    sql = sql.Replace("###TABLES###", string.Join(",", tableNames.Select(n => $"'{n}'")));
                }
                else
                {
                    db.Dispose();
                    return;
                }
                db.Database.ExecuteSqlRaw(sql);
                db.Dispose();
            }
            previousTestRequireFullReset = requireFullReset;
            changeTracker = new ChangeTracking();
        }
    }
}
