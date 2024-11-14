using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityFramework
{
    public class ForSuccessDbContextFactory : IDesignTimeDbContextFactory<ForSuccessDbContext>
    {
        //private readonly string _connectionString;

        //public ForSuccessDbContextFactory(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        //public ForSuccessDbContext CreateDbContext(string[] args = null)
        //{
        //    var options = new DbContextOptionsBuilder<ForSuccessDbContext>();

        //    options.UseMySql(_connectionString, MySqlServerVersion.AutoDetect(_connectionString), b => b.MigrationsAssembly("EntityFramework"));

        //    return new ForSuccessDbContext(options.Options);
        //}

        public ForSuccessDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<ForSuccessDbContext>();
            string connectionString = "Server=127.0.0.1;Database=dbforsuccess;User=forsuccess;Password=*!*forsuccess*!*;";

            options.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString));

            return new ForSuccessDbContext(options.Options);
        }
    }
}
