/*
    This class implements the functionality to migrate the database at runtime 
    aftyr a migration is performed as described in the  Database context file. 
    Methods to seed the database with test, initial, or default data are included.
*/

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthIR.Core.Data {
    public static class DBContextExtensions {
        public static bool AllMigrationsApplied (this DbContext context) {
            var applied = context.GetService<IHistoryRepository> ()
                .GetAppliedMigrations ()
                .Select (m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly> ()
                .Migrations
                .Select (m => m.Key);

            return !total.Except (applied).Any ();
        }

    }
}
