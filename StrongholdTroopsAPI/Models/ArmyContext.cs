﻿using Microsoft.EntityFrameworkCore;

namespace StrongholdTroopsAPI.Models
{
    public class ArmyContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Soldiers)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Soldier> Soldiers { get; set;}
    }
}