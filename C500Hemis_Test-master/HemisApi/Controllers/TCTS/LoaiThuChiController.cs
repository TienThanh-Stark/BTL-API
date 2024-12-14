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
    public class LoaiThuChiController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiThuChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbLoaiThuChi>>> GetTbLoaiThuChis()
        {
            return await _context.TbLoaiThuChis.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbLoaiThuChi>> GetTbLoaiThuChi(int id)
        {
            var TbLoaiThuChi = await _context.TbLoaiThuChis.FindAsync(id);

            if (TbLoaiThuChi == null)
            {
                return NotFound();
            }

            return TbLoaiThuChi;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbLoaiThuChi(int id, TbLoaiThuChi TbLoaiThuChi)
        {
            if (id != TbLoaiThuChi.IdLoaiThuChi)
            {
                return BadRequest();
            }

            _context.Entry(TbLoaiThuChi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbLoaiThuChiExists(id))
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
        public async Task<ActionResult<TbLoaiThuChi>> PostTbLoaiThuChi(TbLoaiThuChi TbLoaiThuChi)
        {
            _context.TbLoaiThuChis.Add(TbLoaiThuChi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbLoaiThuChiExists(TbLoaiThuChi.IdLoaiThuChi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbLoaiThuChi", new { id = TbLoaiThuChi.IdLoaiThuChi }, TbLoaiThuChi);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbLoaiThuChi(int id)
        {
            var TbLoaiThuChi = await _context.TbLoaiThuChis.FindAsync(id);
            if (TbLoaiThuChi == null)
            {
                return NotFound();
            }

            _context.TbLoaiThuChis.Remove(TbLoaiThuChi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbLoaiThuChiExists(int id)
        {
            return _context.TbLoaiThuChis.Any(e => e.IdLoaiThuChi == id);
        }
    }
}
