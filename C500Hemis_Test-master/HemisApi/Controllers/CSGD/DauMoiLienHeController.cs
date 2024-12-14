using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSGD
{
    [Route("api/csgd/[controller]")]
    [ApiController]
    public class DauMoiLienHeController : ControllerBase
    {
        private readonly HemisContext _context;

        public DauMoiLienHeController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDauMoiLienHe>>> GetTbDauMoiLienHes()
        {
            return await _context.TbDauMoiLienHes.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDauMoiLienHe>> GetTbDauMoiLienHe(int id)
        {
            var TbDauMoiLienHe = await _context.TbDauMoiLienHes.FindAsync(id);

            if (TbDauMoiLienHe == null)
            {
                return NotFound();
            }

            return TbDauMoiLienHe;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDauMoiLienHe(int id, TbDauMoiLienHe TbDauMoiLienHe)
        {
            if (id != TbDauMoiLienHe.IdDauMoiLienHe)
            {
                return BadRequest();
            }

            _context.Entry(TbDauMoiLienHe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDauMoiLienHeExists(id))
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
        public async Task<ActionResult<TbDauMoiLienHe>> PostTbDauMoiLienHe(TbDauMoiLienHe TbDauMoiLienHe)
        {
            _context.TbDauMoiLienHes.Add(TbDauMoiLienHe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDauMoiLienHeExists(TbDauMoiLienHe.IdDauMoiLienHe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDauMoiLienHe", new { id = TbDauMoiLienHe.IdDauMoiLienHe }, TbDauMoiLienHe);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDauMoiLienHe(int id)
        {
            var TbDauMoiLienHe = await _context.TbDauMoiLienHes.FindAsync(id);
            if (TbDauMoiLienHe == null)
            {
                return NotFound();
            }

            _context.TbDauMoiLienHes.Remove(TbDauMoiLienHe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDauMoiLienHeExists(int id)
        {
            return _context.TbDauMoiLienHes.Any(e => e.IdDauMoiLienHe == id);
        }
    }
}
