﻿using Microsoft.EntityFrameworkCore;

namespace StrongholdTroopsAPI.Models
{

    /// <summary>
    /// Army context class which gives blueprint for the DB
    /// </summary>
    public class ArmyContext : DbContext
    {
        public ArmyContext(DbContextOptions<ArmyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Soldiers)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);
            modelBuilder.Seed();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Soldier> Soldiers { get; set;}
    }
}
