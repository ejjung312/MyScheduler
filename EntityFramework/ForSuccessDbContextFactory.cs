using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityFramework
{
    public class ForSuccessDbContextFactory //: IDesignTimeDbContextFactory<ForSuccessDbContext>
    {
        private readonly string _connectionString;

        public ForSuccessDbContextFactory()
        {
        }

        public ForSuccessDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ForSuccessDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<ForSuccessDbContext>();

            options.UseMySql(_connectionString, MySqlServerVersion.AutoDetect(_connectionString));

            return new ForSuccessDbContext(options.Options);
        }
    }
}
