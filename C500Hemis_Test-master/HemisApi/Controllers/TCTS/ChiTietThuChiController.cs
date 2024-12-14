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
    public class ChiTietThuChiController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChiTietThuChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbChiTietThuChi>>> GetTbChiTietThuChis()
        {
            return await _context.TbChiTietThuChis.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbChiTietThuChi>> GetTbChiTietThuChi(int id)
        {
            var TbChiTietThuChi = await _context.TbChiTietThuChis.FindAsync(id);

            if (TbChiTietThuChi == null)
            {
                return NotFound();
            }

            return TbChiTietThuChi;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbChiTietThuChi(int id, TbChiTietThuChi TbChiTietThuChi)
        {
            if (id != TbChiTietThuChi.IdChiTietThuChi)
            {
                return BadRequest();
            }

            _context.Entry(TbChiTietThuChi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbChiTietThuChiExists(id))
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
        public async Task<ActionResult<TbChiTietThuChi>> PostTbChiTietThuChi(TbChiTietThuChi TbChiTietThuChi)
        {
            _context.TbChiTietThuChis.Add(TbChiTietThuChi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbChiTietThuChiExists(TbChiTietThuChi.IdChiTietThuChi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbChiTietThuChi", new { id = TbChiTietThuChi.IdChiTietThuChi }, TbChiTietThuChi);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbChiTietThuChi(int id)
        {
            var TbChiTietThuChi = await _context.TbChiTietThuChis.FindAsync(id);
            if (TbChiTietThuChi == null)
            {
                return NotFound();
            }

            _context.TbChiTietThuChis.Remove(TbChiTietThuChi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbChiTietThuChiExists(int id)
        {
            return _context.TbChiTietThuChis.Any(e => e.IdChiTietThuChi == id);
        }
    }
}
