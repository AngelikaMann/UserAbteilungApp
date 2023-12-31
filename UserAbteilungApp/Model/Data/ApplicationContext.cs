﻿using Microsoft.EntityFrameworkCore;

namespace UserAbteilungApp.Model.Data
{
    public class ApplicationContext : DbContext

    {
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ManageDb;Trusted_Connection=True;");
        }
    }
}