using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace StrongholdTroopsAPI.Models
{
    /// <summary>
    /// This class has a methods called seed to populate the in memory database when the solution is built
    /// </summary>
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Archery", Description = "Shoots arrows from Distance" },
                new Category { Id = 2, Name = "Foot Soldier", Description = "Contains troops which are muscle of the army and travels by foot" },
                new Category { Id = 3, Name = "Riders", Description = "Troops traveling by horses" });

            modelbuilder.Entity<Soldier>().HasData(
                new Soldier { Id = 1, CategoryId = 2, Name = "Spearman", Cost = 1, Damage = 1 },
                new Soldier { Id = 2, CategoryId = 1, Name = "Archer", Cost = 1, Damage = 1 },
                new Soldier { Id = 3, CategoryId = 2, Name = "Maceman", Cost = 1, Damage = 1 },
                new Soldier { Id = 4, CategoryId = 1, Name = "Crossbowman", Cost = 1, Damage = 1 },
                new Soldier { Id = 5, CategoryId = 2, Name = "Pikeman", Cost = 1, Damage = 1 },
                new Soldier { Id = 6, CategoryId = 2, Name = "Swordsman", Cost = 1, Damage = 1 },
                new Soldier { Id = 7, CategoryId = 3, Name = "Knight", Cost = 1, Damage = 1 },
                new Soldier { Id = 8, CategoryId = 1, Name = "Arabian Bowman", Cost = 1, Damage = 1 },
                new Soldier { Id = 9, CategoryId = 2, Name = "Slave", Cost = 1, Damage = 1 },
                new Soldier { Id = 10, CategoryId = 1, Name = "Slinger", Cost = 1, Damage = 1 },
                new Soldier { Id = 11, CategoryId = 2, Name = "Arabin Swordsman", Cost = 1, Damage = 1 },
                new Soldier { Id = 12, CategoryId = 3, Name = "Horse Archer", Cost = 1, Damage = 1 },
                new Soldier { Id = 13, CategoryId = 1, Name = "Fire Thrower", Cost = 1, Damage = 1 });                
        }
    }
}
