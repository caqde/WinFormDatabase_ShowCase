using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Code based on code from https://www.mikee.se/posts/fastest_way_to_reset_database_with_ef_core_20220103
//SQL statements converted to PostgreSQL Syntax from T-SQL

namespace ShowCaseModelUnitTests.TestTools
{
    public class ChangeTracking : ISaveChangesInterceptor
    {
        private readonly HashSet<string> affectedTables = new HashSet<string>();

        public IReadOnlyCollection<string> GetAffectedTables() { return affectedTables.ToList().AsReadOnly(); }

        public void SaveChangesFailed(DbContextErrorEventData eventData)
        {
            // Method intentionally left empty.
        }
        public Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default) { return Task.CompletedTask; }
        public int SavedChanges(SaveChangesCompletedEventData eventData, int result) { return result; }
        public async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default) { return result; }

        public InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            LogAdditions(eventData.Context);
            return result;
        }

        public async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            LogAdditions(eventData.Context);
            return result;
        }

        private void LogAdditions(DbContext context)
        {
            context.ChangeTracker.DetectChanges();

            foreach (var entry in context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                affectedTables.Add(entry.Metadata.GetTableName());
            }
        }
    }
}
