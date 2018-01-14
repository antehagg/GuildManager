using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuildManager.Data.GameData.Items;

namespace GuildManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Weapons")]
    public class WeaponsController : Controller
    {
        private readonly GuildManagerContext _context;

        public WeaponsController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/Weapons
        [HttpGet]
        public IEnumerable<DbWeapon> GetWeapons()
        {
            return _context.Weapons;
        }

        // GET: api/Weapons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDbWeapon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbWeapon = await _context.Weapons.SingleOrDefaultAsync(m => m.Id == id);

            if (dbWeapon == null)
            {
                return NotFound();
            }

            return Ok(dbWeapon);
        }

        // PUT: api/Weapons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbWeapon([FromRoute] int id, [FromBody] DbWeapon dbWeapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dbWeapon.Id)
            {
                return BadRequest();
            }

            _context.Entry(dbWeapon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbWeaponExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weapons
        [HttpPost]
        public async Task<IActionResult> PostDbWeapon([FromBody] DbWeapon dbWeapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Weapons.Add(dbWeapon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbWeapon", new { id = dbWeapon.Id }, dbWeapon);
        }

        // DELETE: api/Weapons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDbWeapon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbWeapon = await _context.Weapons.SingleOrDefaultAsync(m => m.Id == id);
            if (dbWeapon == null)
            {
                return NotFound();
            }

            _context.Weapons.Remove(dbWeapon);
            await _context.SaveChangesAsync();

            return Ok(dbWeapon);
        }

        private bool DbWeaponExists(int id)
        {
            return _context.Weapons.Any(e => e.Id == id);
        }
    }
}