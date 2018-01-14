using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuildManager.Api.Data;
using GuildManager.Data.GameData.Items;

namespace GuildManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Items")]
    public class ItemsController : Controller
    {
        private readonly GuildManagerContext _context;

        public ItemsController(GuildManagerContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<DbItem> GetItem()
        {
            return _context.DbItem;
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDbItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbItem = await _context.DbItem.Include(s => s.Stats).SingleOrDefaultAsync(m => m.Id == id);

            if (dbItem == null)
            {
                return NotFound();
            }

            return Ok(dbItem);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbItem([FromRoute] int id, [FromBody] DbItem dbItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dbItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(dbItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbItemExists(id))
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

        // POST: api/Items
        [HttpPost]
        public async Task<IActionResult> PostDbItem([FromBody] DbItem dbItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DbItem.Add(dbItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbItem", new { id = dbItem.Id }, dbItem);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDbItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbItem = await _context.DbItem.SingleOrDefaultAsync(m => m.Id == id);
            if (dbItem == null)
            {
                return NotFound();
            }

            _context.DbItem.Remove(dbItem);
            await _context.SaveChangesAsync();

            return Ok(dbItem);
        }

        private bool DbItemExists(int id)
        {
            return _context.DbItem.Any(e => e.Id == id);
        }
    }
}