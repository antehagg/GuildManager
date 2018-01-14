using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuildManager.Api.Data;
using GuildManager.Data.GameData.Abilities;

namespace GuildManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Effects")]
    public class EffectsController : Controller
    {
        private readonly GuildManagerContext _context;

        public EffectsController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/Effects
        [HttpGet]
        public IEnumerable<Effect> GetEffect()
        {
            return _context.Effect;
        }

        // GET: api/Effects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEffectById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var effect = await _context.Effect.SingleOrDefaultAsync(m => m.Id == id);

            if (effect == null)
            {
                return NotFound();
            }

            return Ok(effect);
        }

        // PUT: api/Effects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEffect([FromRoute] int id, [FromBody] Effect effect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != effect.Id)
            {
                return BadRequest();
            }

            _context.Entry(effect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EffectExists(id))
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

        // POST: api/Effects
        [HttpPost]
        public async Task<IActionResult> PostEffect([FromBody] Effect effect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Effect.Add(effect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEffect", new { id = effect.Id }, effect);
        }

        // DELETE: api/Effects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEffect([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var effect = await _context.Effect.SingleOrDefaultAsync(m => m.Id == id);
            if (effect == null)
            {
                return NotFound();
            }

            _context.Effect.Remove(effect);
            await _context.SaveChangesAsync();

            return Ok(effect);
        }

        private bool EffectExists(int id)
        {
            return _context.Effect.Any(e => e.Id == id);
        }
    }
}