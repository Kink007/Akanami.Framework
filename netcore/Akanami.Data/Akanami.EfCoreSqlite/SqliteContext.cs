using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Akanami.EfCoreSqlite
{
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=test.db");
        //    //base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }

    public class BloggingContextFactory : IDesignTimeDbContextFactory<SqliteContext>
    {
        public SqliteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqliteContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");

            return new SqliteContext(optionsBuilder.Options);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
