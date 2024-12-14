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
    public class PhongThiNghiemController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhongThiNghiemController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPhongThiNghiem>>> GetTbPhongThiNghiems()
        {
            return await _context.TbPhongThiNghiems.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPhongThiNghiem>> GetTbPhongThiNghiem(int id)
        {
            var TbPhongThiNghiem = await _context.TbPhongThiNghiems.FindAsync(id);

            if (TbPhongThiNghiem == null)
            {
                return NotFound();
            }

            return TbPhongThiNghiem;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPhongThiNghiem(int id, TbPhongThiNghiem TbPhongThiNghiem)
        {
            if (id != TbPhongThiNghiem.IdPhongThiNghiem)
            {
                return BadRequest();
            }

            _context.Entry(TbPhongThiNghiem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPhongThiNghiemExists(id))
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
        public async Task<ActionResult<TbPhongThiNghiem>> PostTbPhongThiNghiem(TbPhongThiNghiem TbPhongThiNghiem)
        {
            _context.TbPhongThiNghiems.Add(TbPhongThiNghiem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbPhongThiNghiemExists(TbPhongThiNghiem.IdPhongThiNghiem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbPhongThiNghiem", new { id = TbPhongThiNghiem.IdPhongThiNghiem }, TbPhongThiNghiem);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPhongThiNghiem(int id)
        {
            var TbPhongThiNghiem = await _context.TbPhongThiNghiems.FindAsync(id);
            if (TbPhongThiNghiem == null)
            {
                return NotFound();
            }

            _context.TbPhongThiNghiems.Remove(TbPhongThiNghiem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPhongThiNghiemExists(int id)
        {
            return _context.TbPhongThiNghiems.Any(e => e.IdPhongThiNghiem == id);
        }
    }
}
