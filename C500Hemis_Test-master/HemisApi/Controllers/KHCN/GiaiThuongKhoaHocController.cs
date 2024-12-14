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
    public class GiaiThuongKhoaHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public GiaiThuongKhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGiaiThuongKhoaHoc>>> GetTbGiaiThuongKhoaHocs()
        {
            return await _context.TbGiaiThuongKhoaHocs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGiaiThuongKhoaHoc>> GetTbGiaiThuongKhoaHoc(int id)
        {
            var TbGiaiThuongKhoaHoc = await _context.TbGiaiThuongKhoaHocs.FindAsync(id);

            if (TbGiaiThuongKhoaHoc == null)
            {
                return NotFound();
            }

            return TbGiaiThuongKhoaHoc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGiaiThuongKhoaHoc(int id, TbGiaiThuongKhoaHoc TbGiaiThuongKhoaHoc)
        {
            if (id != TbGiaiThuongKhoaHoc.IdGiaiThuongKhoaHoc)
            {
                return BadRequest();
            }

            _context.Entry(TbGiaiThuongKhoaHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGiaiThuongKhoaHocExists(id))
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
        public async Task<ActionResult<TbGiaiThuongKhoaHoc>> PostTbGiaiThuongKhoaHoc(TbGiaiThuongKhoaHoc TbGiaiThuongKhoaHoc)
        {
            _context.TbGiaiThuongKhoaHocs.Add(TbGiaiThuongKhoaHoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbGiaiThuongKhoaHocExists(TbGiaiThuongKhoaHoc.IdGiaiThuongKhoaHoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbGiaiThuongKhoaHoc", new { id = TbGiaiThuongKhoaHoc.IdGiaiThuongKhoaHoc }, TbGiaiThuongKhoaHoc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGiaiThuongKhoaHoc(int id)
        {
            var TbGiaiThuongKhoaHoc = await _context.TbGiaiThuongKhoaHocs.FindAsync(id);
            if (TbGiaiThuongKhoaHoc == null)
            {
                return NotFound();
            }

            _context.TbGiaiThuongKhoaHocs.Remove(TbGiaiThuongKhoaHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGiaiThuongKhoaHocExists(int id)
        {
            return _context.TbGiaiThuongKhoaHocs.Any(e => e.IdGiaiThuongKhoaHoc == id);
        }
    }
}
