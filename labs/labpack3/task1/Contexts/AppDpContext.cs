using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using task1.Models;

namespace task1.Contexts
{
    public class AppDpContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dpPath = GetDatabasePath("app.db");
            optionsBuilder.UseSqlite($"Data Source={dpPath}");
            Database.EnsureCreated();
        }

        private static string GetDatabasePath(string fileName)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(folder, fileName);
        }
    }
}
