using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;
namespace HemisApi.Controllers.HTQT
{
    [Route("api/htqt/[controller]")]
    [ApiController]
    public class HoiThaoHoiNghiController : ControllerBase
    {
        private readonly HemisContext _context;

        public HoiThaoHoiNghiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHoiThaoHoiNghi>>> GetTbHoiThaoHoiNghis()
        {
            return await _context.TbHoiThaoHoiNghis.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHoiThaoHoiNghi>> GetTbHoiThaoHoiNghi(int id)
        {
            var TbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis.FindAsync(id);

            if (TbHoiThaoHoiNghi == null)
            {
                return NotFound();
            }

            return TbHoiThaoHoiNghi;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHoiThaoHoiNghi(int id, TbHoiThaoHoiNghi TbHoiThaoHoiNghi)
        {
            if (id != TbHoiThaoHoiNghi.IdHoiThaoHoiNghi)
            {
                return BadRequest();
            }

            _context.Entry(TbHoiThaoHoiNghi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHoiThaoHoiNghiExists(id))
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
        public async Task<ActionResult<TbHoiThaoHoiNghi>> PostTbHoiThaoHoiNghi(TbHoiThaoHoiNghi TbHoiThaoHoiNghi)
        {
            _context.TbHoiThaoHoiNghis.Add(TbHoiThaoHoiNghi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbHoiThaoHoiNghiExists(TbHoiThaoHoiNghi.IdHoiThaoHoiNghi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbHoiThaoHoiNghi", new { id = TbHoiThaoHoiNghi.IdHoiThaoHoiNghi }, TbHoiThaoHoiNghi);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbHoiThaoHoiNghi(int id)
        {
            var TbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis.FindAsync(id);
            if (TbHoiThaoHoiNghi == null)
            {
                return NotFound();
            }

            _context.TbHoiThaoHoiNghis.Remove(TbHoiThaoHoiNghi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbHoiThaoHoiNghiExists(int id)
        {
            return _context.TbHoiThaoHoiNghis.Any(e => e.IdHoiThaoHoiNghi == id);
        }
    }
}
