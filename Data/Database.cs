using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace RecipeMaker
{
    public class Database : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
       
        public Database() : base() { }
        public Database(DbContextOptions<Database> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {if (options.IsConfigured is false)
            {
                var basedir = System.AppContext.BaseDirectory;
                var solndir = Directory.GetParent(basedir).Parent.Parent.Parent.Parent;
                options.UseSqlite($"Data Source={solndir.FullName}/db/app.db");
            }

            // to disable change tracking
            // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            // db.Entry(some_obj).State = EntityState.Detached;

            // use either option below to log the queries to the console
            // options.LogTo(Console.WriteLine, LogLevel.Information);
            // options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            // displays parameter values in logs
            options.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
         }
    }
}