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
    public class HoatDongBaoVeMoiTruongController : ControllerBase
    {
        private readonly HemisContext _context;

        public HoatDongBaoVeMoiTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHoatDongBaoVeMoiTruong>>> GetTbHoatDongBaoVeMoiTruongs()
        {
            return await _context.TbHoatDongBaoVeMoiTruongs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHoatDongBaoVeMoiTruong>> GetTbHoatDongBaoVeMoiTruong(int id)
        {
            var TbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs.FindAsync(id);

            if (TbHoatDongBaoVeMoiTruong == null)
            {
                return NotFound();
            }

            return TbHoatDongBaoVeMoiTruong;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHoatDongBaoVeMoiTruong(int id, TbHoatDongBaoVeMoiTruong TbHoatDongBaoVeMoiTruong)
        {
            if (id != TbHoatDongBaoVeMoiTruong.IdHoatDongBaoVeMoiTruong)
            {
                return BadRequest();
            }

            _context.Entry(TbHoatDongBaoVeMoiTruong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHoatDongBaoVeMoiTruongExists(id))
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
        public async Task<ActionResult<TbHoatDongBaoVeMoiTruong>> PostTbHoatDongBaoVeMoiTruong(TbHoatDongBaoVeMoiTruong TbHoatDongBaoVeMoiTruong)
        {
            _context.TbHoatDongBaoVeMoiTruongs.Add(TbHoatDongBaoVeMoiTruong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbHoatDongBaoVeMoiTruongExists(TbHoatDongBaoVeMoiTruong.IdHoatDongBaoVeMoiTruong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbHoatDongBaoVeMoiTruong", new { id = TbHoatDongBaoVeMoiTruong.IdHoatDongBaoVeMoiTruong }, TbHoatDongBaoVeMoiTruong);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbHoatDongBaoVeMoiTruong(int id)
        {
            var TbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs.FindAsync(id);
            if (TbHoatDongBaoVeMoiTruong == null)
            {
                return NotFound();
            }

            _context.TbHoatDongBaoVeMoiTruongs.Remove(TbHoatDongBaoVeMoiTruong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbHoatDongBaoVeMoiTruongExists(int id)
        {
            return _context.TbHoatDongBaoVeMoiTruongs.Any(e => e.IdHoatDongBaoVeMoiTruong == id);
        }
    }
}
