using EFInfrastructure.Contexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Test
{
    public class ApplicationServiceTestBase : IDisposable
    {
        private readonly DbConnection _connection;

        protected SBIDbContext DbContext{ get; }

        public ApplicationServiceTestBase()
        {
            DbContextOptions<SBIDbContext> options = new DbContextOptionsBuilder<SBIDbContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning))
                .Options;

            _connection = RelationalOptionsExtension.Extract(options).Connection;

            DbContext = new SBIDbContext(options);

            DbContext.Database.EnsureCreated();
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose() => _connection.Dispose();
    }
}
