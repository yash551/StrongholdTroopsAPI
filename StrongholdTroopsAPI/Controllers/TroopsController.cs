using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrongholdTroopsAPI.Models;

namespace StrongholdTroopsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TroopsController : ControllerBase
    {
        //initiating ArmyContext object
        private readonly ArmyContext _armyContext;

        public TroopsController(ArmyContext armyContext)
        {
            _armyContext = armyContext;
            _armyContext.Database.EnsureCreated();
        }

        //method to get all soldiers
        [HttpGet]
        public async Task<ActionResult> GetAllSoldiers()
        {
            var soldiers =  await _armyContext.Soldiers.ToArrayAsync();
            return Ok(soldiers);
        }

        //method to get a soldier with a specific id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSoldier(int id)
        {
            var soldier = await _armyContext.Soldiers.FindAsync(id);
            if (soldier == null) { return NotFound(); }
            return Ok(soldier);
        }

        [HttpPost]
        public async Task<ActionResult> PostSoldier(Soldier soldier)
        {
            if(!ModelState.IsValid) { return BadRequest(); }

            _armyContext.Soldiers.Add(soldier);
            await _armyContext.SaveChangesAsync();
            return CreatedAtAction(
                "GetSoldier",
                new { id = soldier.Id },
                soldier);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSoldier(int id)
        {
            var soldier = await _armyContext.Soldiers.FindAsync(id);
            if (soldier == null) { return NotFound(); }
            _armyContext.Soldiers.Remove(soldier);
            return Ok(soldier);
        }
    }
}
