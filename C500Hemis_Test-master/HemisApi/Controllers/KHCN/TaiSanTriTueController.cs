using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CTDT
{
    [Route("api/ctdt/[controller]")]
    [ApiController]
    public class TaiSanTriTueController : ControllerBase
    {
        private readonly HemisContext _context;

        public TaiSanTriTueController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTaiSanTriTue>>> GetTbTaiSanTriTues()
        {
            return await _context.TbTaiSanTriTues.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTaiSanTriTue>> GetTbTaiSanTriTue(int id)
        {
            var TbTaiSanTriTue = await _context.TbTaiSanTriTues.FindAsync(id);

            if (TbTaiSanTriTue == null)
            {
                return NotFound();
            }

            return TbTaiSanTriTue;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTaiSanTriTue(int id, TbTaiSanTriTue TbTaiSanTriTue)
        {
            if (id != TbTaiSanTriTue.IdTaiSanTriTue)
            {
                return BadRequest();
            }

            _context.Entry(TbTaiSanTriTue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTaiSanTriTueExists(id))
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

        // POST: api/CanBo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbTaiSanTriTue>> PostTbTaiSanTriTue(TbTaiSanTriTue TbTaiSanTriTue)
        {
            _context.TbTaiSanTriTues.Add(TbTaiSanTriTue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbTaiSanTriTueExists(TbTaiSanTriTue.IdTaiSanTriTue))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbTaiSanTriTue", new { id = TbTaiSanTriTue.IdTaiSanTriTue }, TbTaiSanTriTue);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbTaiSanTriTue(int id)
        {
            var TbTaiSanTriTue = await _context.TbTaiSanTriTues.FindAsync(id);
            if (TbTaiSanTriTue == null)
            {
                return NotFound();
            }

            _context.TbTaiSanTriTues.Remove(TbTaiSanTriTue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbTaiSanTriTueExists(int id)
        {
            return _context.TbTaiSanTriTues.Any(e => e.IdTaiSanTriTue == id);
        }
    }
}
