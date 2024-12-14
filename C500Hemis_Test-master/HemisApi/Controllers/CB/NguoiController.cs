using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CB
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiController : ControllerBase
    {
        private readonly HemisContext _context;

        public NguoiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/Nguoi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNguoi>>> GetTbNguois()
        {
            return await _context.TbNguois.ToListAsync();
        }

        // GET: api/Nguoi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNguoi>> GetTbNguoi(int id)
        {
            var tbNguoi = await _context.TbNguois.FindAsync(id);

            if (tbNguoi == null)
            {
                return NotFound();
            }

            return tbNguoi;
        }

        // PUT: api/Nguoi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNguoi(int id, TbNguoi tbNguoi)
        {
            if (id != tbNguoi.IdNguoi)
            {
                return BadRequest();
            }

            _context.Entry(tbNguoi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNguoiExists(id))
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

        // POST: api/Nguoi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbNguoi>> PostTbNguoi(TbNguoi tbNguoi)
        {
            _context.TbNguois.Add(tbNguoi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNguoiExists(tbNguoi.IdNguoi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNguoi", new { id = tbNguoi.IdNguoi }, tbNguoi);
        }

        // DELETE: api/Nguoi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNguoi(int id)
        {
            var tbNguoi = await _context.TbNguois.FindAsync(id);
            if (tbNguoi == null)
            {
                return NotFound();
            }

            _context.TbNguois.Remove(tbNguoi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNguoiExists(int id)
        {
            return _context.TbNguois.Any(e => e.IdNguoi == id);
        }
    }
}
