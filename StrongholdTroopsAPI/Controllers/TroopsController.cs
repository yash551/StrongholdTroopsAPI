using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrongholdTroopsAPI.Models;
using System.Net.Http.Headers;

namespace StrongholdTroopsAPI.Controllers
{

    /// <summary>
    /// Controller class which helds methods for get, update and delete soldiers from the database
    /// </summary>
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

        //method to add a soldier in the DB
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


        //method to update a soldier from DB
        [HttpPut("{id}")]
        public async Task<ActionResult> PutSoldier(int id, Soldier soldier)
        {
            if (id != soldier.Id) { return BadRequest(ModelState); }

            _armyContext.Entry(soldier).State = EntityState.Modified;

            try
            {
                await _armyContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_armyContext.Soldiers.Any(s => s.Id == id))
                { return NotFound(); }
                else
                { throw; }
            }
            return NoContent();
        }

        //method to delete a soldier from DB
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSoldier(int id)
        {
            var soldier = await _armyContext.Soldiers.FindAsync(id);
            if (soldier == null) { return NotFound(); }
            _armyContext.Soldiers.Remove(soldier);
            await _armyContext.SaveChangesAsync();
            return Ok(soldier);
        }
    }
}
