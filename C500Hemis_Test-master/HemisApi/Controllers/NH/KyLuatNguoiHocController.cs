using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.NH
{
    [Route("api/nh/[controller]")]
    [ApiController]
    public class KyLuatNguoiHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public KyLuatNguoiHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKyLuatNguoiHoc>>> GetTbKyLuatNguoiHocs()
        {
            return await _context.TbKyLuatNguoiHocs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKyLuatNguoiHoc>> GetTbKyLuatNguoiHoc(int id)
        {
            var TbKyLuatNguoiHoc = await _context.TbKyLuatNguoiHocs.FindAsync(id);

            if (TbKyLuatNguoiHoc == null)
            {
                return NotFound();
            }

            return TbKyLuatNguoiHoc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKyLuatNguoiHoc(int id, TbKyLuatNguoiHoc TbKyLuatNguoiHoc)
        {
            if (id != TbKyLuatNguoiHoc.IdKyLuatNguoiHoc)
            {
                return BadRequest();
            }

            _context.Entry(TbKyLuatNguoiHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKyLuatNguoiHocExists(id))
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
        public async Task<ActionResult<TbKyLuatNguoiHoc>> PostTbKyLuatNguoiHoc(TbKyLuatNguoiHoc TbKyLuatNguoiHoc)
        {
            _context.TbKyLuatNguoiHocs.Add(TbKyLuatNguoiHoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbKyLuatNguoiHocExists(TbKyLuatNguoiHoc.IdKyLuatNguoiHoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbKyLuatNguoiHoc", new { id = TbKyLuatNguoiHoc.IdKyLuatNguoiHoc }, TbKyLuatNguoiHoc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKyLuatNguoiHoc(int id)
        {
            var TbKyLuatNguoiHoc = await _context.TbKyLuatNguoiHocs.FindAsync(id);
            if (TbKyLuatNguoiHoc == null)
            {
                return NotFound();
            }

            _context.TbKyLuatNguoiHocs.Remove(TbKyLuatNguoiHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKyLuatNguoiHocExists(int id)
        {
            return _context.TbKyLuatNguoiHocs.Any(e => e.IdKyLuatNguoiHoc == id);
        }
    }
}
