using Microsoft.AspNetCore.Mvc;

namespace StrongholdTroopsAPI.Models
{
    public class Category 
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        public virtual List<Soldier> Soldiers { get; set;}
    }
}
