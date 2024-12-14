using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSVC
{
    [Route("api/csvc/[controller]")]
    [ApiController]
    public class PhongHocGiangDuongHoiTruongController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhongHocGiangDuongHoiTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPhongHocGiangDuongHoiTruong>>> GetTbPhongHocGiangDuongHoiTruongs()
        {
            return await _context.TbPhongHocGiangDuongHoiTruongs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPhongHocGiangDuongHoiTruong>> GetTbPhongHocGiangDuongHoiTruong(int id)
        {
            var TbPhongHocGiangDuongHoiTruong = await _context.TbPhongHocGiangDuongHoiTruongs.FindAsync(id);

            if (TbPhongHocGiangDuongHoiTruong == null)
            {
                return NotFound();
            }

            return TbPhongHocGiangDuongHoiTruong;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPhongHocGiangDuongHoiTruong(int id, TbPhongHocGiangDuongHoiTruong TbPhongHocGiangDuongHoiTruong)
        {
            if (id != TbPhongHocGiangDuongHoiTruong.IdPhongHocGiangDuongHoiTruong)
            {
                return BadRequest();
            }

            _context.Entry(TbPhongHocGiangDuongHoiTruong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPhongHocGiangDuongHoiTruongExists(id))
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
        public async Task<ActionResult<TbPhongHocGiangDuongHoiTruong>> PostTbPhongHocGiangDuongHoiTruong(TbPhongHocGiangDuongHoiTruong TbPhongHocGiangDuongHoiTruong)
        {
            _context.TbPhongHocGiangDuongHoiTruongs.Add(TbPhongHocGiangDuongHoiTruong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbPhongHocGiangDuongHoiTruongExists(TbPhongHocGiangDuongHoiTruong.IdPhongHocGiangDuongHoiTruong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbPhongHocGiangDuongHoiTruong", new { id = TbPhongHocGiangDuongHoiTruong.IdPhongHocGiangDuongHoiTruong }, TbPhongHocGiangDuongHoiTruong);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPhongHocGiangDuongHoiTruong(int id)
        {
            var TbPhongHocGiangDuongHoiTruong = await _context.TbPhongHocGiangDuongHoiTruongs.FindAsync(id);
            if (TbPhongHocGiangDuongHoiTruong == null)
            {
                return NotFound();
            }

            _context.TbPhongHocGiangDuongHoiTruongs.Remove(TbPhongHocGiangDuongHoiTruong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPhongHocGiangDuongHoiTruongExists(int id)
        {
            return _context.TbPhongHocGiangDuongHoiTruongs.Any(e => e.IdPhongHocGiangDuongHoiTruong == id);
        }
    }
}
