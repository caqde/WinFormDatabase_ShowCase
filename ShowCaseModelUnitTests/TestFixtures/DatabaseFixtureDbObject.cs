using AutoMapper;
using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ShowCaseModel.Models;
using ShowCaseModelUnitTests.TestTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModelUnitTests.TestFixtures
{
    public class DatabaseFixtureDbObject : IDisposable
    {
        private DbObjectModel dbObjectModel { get; set; }

        public DbObjectModel DbObjectModel { get { return dbObjectModel; } }

        public DatabaseFixtureDbObject()
        {
            SetupOptions();
            RunMigrations();
        }

        private void SetupOptions()
        {
            dbObjectModel = new DbObjectModel(DatabaseTracker.GetOptionBuilder().Options);
        }

        private void RunMigrations()
        {
            var context = new ShowCaseDbContext(DatabaseTracker.GetOptionBuilder().Options);
            context.Database.EnsureDeleted();
            if (context.Database.GetPendingMigrations().Any())
            {
                var migrator = context.Database.GetService<IMigrator>();
                migrator.Migrate();
            }
            context.Database.EnsureCreated();
            context.Dispose();
        }

        public void Dispose()
        {
            // Method intentionally left empty.
            GC.SuppressFinalize(this);
        }
    }
}
