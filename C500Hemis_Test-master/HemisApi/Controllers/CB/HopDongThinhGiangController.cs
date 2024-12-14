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
    [Route("api/cb/[controller]")]
    [ApiController]
    public class HopDongThinhGiangController : ControllerBase
    {
        private readonly HemisContext _context;

        public HopDongThinhGiangController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHopDongThinhGiang>>> GetTbHopDongThinhGiangs()
        {
            return await _context.TbHopDongThinhGiangs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHopDongThinhGiang>> GetTbHopDongThinhGiang(int id)
        {
            var TbHopDongThinhGiang = await _context.TbHopDongThinhGiangs.FindAsync(id);

            if (TbHopDongThinhGiang == null)
            {
                return NotFound();
            }

            return TbHopDongThinhGiang;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHopDongThinhGiang(int id, TbHopDongThinhGiang TbHopDongThinhGiang)
        {
            if (id != TbHopDongThinhGiang.IdHopDongThinhGiang)
            {
                return BadRequest();
            }

            _context.Entry(TbHopDongThinhGiang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHopDongThinhGiangExists(id))
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
        public async Task<ActionResult<TbHopDongThinhGiang>> PostTbHopDongThinhGiang(TbHopDongThinhGiang TbHopDongThinhGiang)
        {
            _context.TbHopDongThinhGiangs.Add(TbHopDongThinhGiang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbHopDongThinhGiangExists(TbHopDongThinhGiang.IdHopDongThinhGiang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbHopDongThinhGiang", new { id = TbHopDongThinhGiang.IdHopDongThinhGiang }, TbHopDongThinhGiang);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbHopDongThinhGiang(int id)
        {
            var TbHopDongThinhGiang = await _context.TbHopDongThinhGiangs.FindAsync(id);
            if (TbHopDongThinhGiang == null)
            {
                return NotFound();
            }

            _context.TbHopDongThinhGiangs.Remove(TbHopDongThinhGiang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbHopDongThinhGiangExists(int id)
        {
            return _context.TbHopDongThinhGiangs.Any(e => e.IdHopDongThinhGiang == id);
        }
    }
}
