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
    public class DatabaseFixtureLibrary : IDisposable
    {
        private Library library {get; set; }
        public Library Library { get { return library; } }

        public DatabaseFixtureLibrary() 
        {
            SetupOptions();
            RunMigrations();
        }

        private void SetupOptions()
        {
            library = new Library(DatabaseTracker.GetOptionBuilder().Options);
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
            GC.SuppressFinalize(this);
        }
    }
}
