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
    public class LichSuDoiTenTruongController : ControllerBase
    {
        private readonly HemisContext _context;

        public LichSuDoiTenTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbLichSuDoiTenTruong>>> GetTbLichSuDoiTenTruongs()
        {
            return await _context.TbLichSuDoiTenTruongs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbLichSuDoiTenTruong>> GetTbLichSuDoiTenTruong(int id)
        {
            var TbLichSuDoiTenTruong = await _context.TbLichSuDoiTenTruongs.FindAsync(id);

            if (TbLichSuDoiTenTruong == null)
            {
                return NotFound();
            }

            return TbLichSuDoiTenTruong;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbLichSuDoiTenTruong(int id, TbLichSuDoiTenTruong TbLichSuDoiTenTruong)
        {
            if (id != TbLichSuDoiTenTruong.IdLichSuDoiTenTruong)
            {
                return BadRequest();
            }

            _context.Entry(TbLichSuDoiTenTruong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbLichSuDoiTenTruongExists(id))
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
        public async Task<ActionResult<TbLichSuDoiTenTruong>> PostTbLichSuDoiTenTruong(TbLichSuDoiTenTruong TbLichSuDoiTenTruong)
        {
            _context.TbLichSuDoiTenTruongs.Add(TbLichSuDoiTenTruong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbLichSuDoiTenTruongExists(TbLichSuDoiTenTruong.IdLichSuDoiTenTruong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbLichSuDoiTenTruong", new { id = TbLichSuDoiTenTruong.IdLichSuDoiTenTruong }, TbLichSuDoiTenTruong);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbLichSuDoiTenTruong(int id)
        {
            var TbLichSuDoiTenTruong = await _context.TbLichSuDoiTenTruongs.FindAsync(id);
            if (TbLichSuDoiTenTruong == null)
            {
                return NotFound();
            }

            _context.TbLichSuDoiTenTruongs.Remove(TbLichSuDoiTenTruong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbLichSuDoiTenTruongExists(int id)
        {
            return _context.TbLichSuDoiTenTruongs.Any(e => e.IdLichSuDoiTenTruong == id);
        }
    }
}
