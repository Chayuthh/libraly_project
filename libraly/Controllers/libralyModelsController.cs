using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libraly.Models;

namespace libraly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class libralyModelsController : ControllerBase
    {
        private readonly libraryContext _context;

        public libralyModelsController(libraryContext context)
        {
            _context = context;
        }

        // GET: api/libralyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<libralyModel>>> GetlibralyModels()
        {
            return await _context.libralyModels.ToListAsync();
        }

        // GET: api/libralyModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<libralyModel>> GetlibralyModel(int id)
        {
            var libralyModel = await _context.libralyModels.FindAsync(id);

            if (libralyModel == null)
            {
                return NotFound();
            }

            return libralyModel;
        }

        // PUT: api/libralyModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutlibralyModel(int id, libralyModel libralyModel)
        {
            if (id != libralyModel.id)
            {
                return BadRequest();
            }

            _context.Entry(libralyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!libralyModelExists(id))
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

        // POST: api/libralyModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<libralyModel>> PostlibralyModel(libralyModel libralyModel)
        {
            _context.libralyModels.Add(libralyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetlibralyModel", new { id = libralyModel.id }, libralyModel);
        }

        // DELETE: api/libralyModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletelibralyModel(int id)
        {
            var libralyModel = await _context.libralyModels.FindAsync(id);
            if (libralyModel == null)
            {
                return NotFound();
            }

            _context.libralyModels.Remove(libralyModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool libralyModelExists(int id)
        {
            return _context.libralyModels.Any(e => e.id == id);
        }
    }
}
