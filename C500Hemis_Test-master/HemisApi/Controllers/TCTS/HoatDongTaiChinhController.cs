using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.TCTS
{
    [Route("api/tcts/[controller]")]
    [ApiController]
    public class HoatDongTaiChinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public HoatDongTaiChinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHoatDongTaiChinh>>> GetTbHoatDongTaiChinhs()
        {
            return await _context.TbHoatDongTaiChinhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHoatDongTaiChinh>> GetTbHoatDongTaiChinh(int id)
        {
            var TbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs.FindAsync(id);

            if (TbHoatDongTaiChinh == null)
            {
                return NotFound();
            }

            return TbHoatDongTaiChinh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHoatDongTaiChinh(int id, TbHoatDongTaiChinh TbHoatDongTaiChinh)
        {
            if (id != TbHoatDongTaiChinh.IdHoatDongTaiChinh)
            {
                return BadRequest();
            }

            _context.Entry(TbHoatDongTaiChinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHoatDongTaiChinhExists(id))
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
        public async Task<ActionResult<TbHoatDongTaiChinh>> PostTbHoatDongTaiChinh(TbHoatDongTaiChinh TbHoatDongTaiChinh)
        {
            _context.TbHoatDongTaiChinhs.Add(TbHoatDongTaiChinh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbHoatDongTaiChinhExists(TbHoatDongTaiChinh.IdHoatDongTaiChinh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbHoatDongTaiChinh", new { id = TbHoatDongTaiChinh.IdHoatDongTaiChinh }, TbHoatDongTaiChinh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbHoatDongTaiChinh(int id)
        {
            var TbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs.FindAsync(id);
            if (TbHoatDongTaiChinh == null)
            {
                return NotFound();
            }

            _context.TbHoatDongTaiChinhs.Remove(TbHoatDongTaiChinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbHoatDongTaiChinhExists(int id)
        {
            return _context.TbHoatDongTaiChinhs.Any(e => e.IdHoatDongTaiChinh == id);
        }
    }
}
