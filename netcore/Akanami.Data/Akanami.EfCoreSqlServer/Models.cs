using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Akanami.EfCoreSqlServer
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            modelBuilder.Entity<UserApp>().HasKey((m) => new { m.UserId, m.AppId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=sampledb;User ID=sa;Password=sa;");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<App> Apps { get; set; }

        public DbSet<UserApp> UserApps { get; set; }

        //public DbSet<UserApp> UserApps { get; set; }
    }

    public class DesignTimeSampleContextFactory : IDesignTimeDbContextFactory<SampleContext>
    {
        public SampleContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SampleContext>();
            builder.UseSqlServer("Server=.;Database=sampledb;User ID=sa;Password=sa;");
            return new SampleContext(builder.Options);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserApp> UserApps { get; set; }
        //public virtual ICollection<App> Apps { get; set; }
    }

    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserApp> UserApps { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }

    public class UserApp
    {
        public int UserId { get; set; }

        public int AppId { get; set; }

        public User User { get; set; }
        public App App { get; set; }

        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<App> Apps { get; set; }
    }
}
