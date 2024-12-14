using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.TS
{
    [Route("api/ts/[controller]")]
    [ApiController]
    public class DanhSachVanBangChungChiController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanhSachVanBangChungChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDanhSachVanBangChungChi>>> GetTbDanhSachVanBangChungChis()
        {
            return await _context.TbDanhSachVanBangChungChis.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDanhSachVanBangChungChi>> GetTbDanhSachVanBangChungChi(int id)
        {
            var TbDanhSachVanBangChungChi = await _context.TbDanhSachVanBangChungChis.FindAsync(id);

            if (TbDanhSachVanBangChungChi == null)
            {
                return NotFound();
            }

            return TbDanhSachVanBangChungChi;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDanhSachVanBangChungChi(int id, TbDanhSachVanBangChungChi TbDanhSachVanBangChungChi)
        {
            if (id != TbDanhSachVanBangChungChi.IdDanhSachVanBangChungChi)
            {
                return BadRequest();
            }

            _context.Entry(TbDanhSachVanBangChungChi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDanhSachVanBangChungChiExists(id))
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
        public async Task<ActionResult<TbDanhSachVanBangChungChi>> PostTbDanhSachVanBangChungChi(TbDanhSachVanBangChungChi TbDanhSachVanBangChungChi)
        {
            _context.TbDanhSachVanBangChungChis.Add(TbDanhSachVanBangChungChi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDanhSachVanBangChungChiExists(TbDanhSachVanBangChungChi.IdDanhSachVanBangChungChi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDanhSachVanBangChungChi", new { id = TbDanhSachVanBangChungChi.IdDanhSachVanBangChungChi }, TbDanhSachVanBangChungChi);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDanhSachVanBangChungChi(int id)
        {
            var TbDanhSachVanBangChungChi = await _context.TbDanhSachVanBangChungChis.FindAsync(id);
            if (TbDanhSachVanBangChungChi == null)
            {
                return NotFound();
            }

            _context.TbDanhSachVanBangChungChis.Remove(TbDanhSachVanBangChungChi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDanhSachVanBangChungChiExists(int id)
        {
            return _context.TbDanhSachVanBangChungChis.Any(e => e.IdDanhSachVanBangChungChi == id);
        }
    }
}
