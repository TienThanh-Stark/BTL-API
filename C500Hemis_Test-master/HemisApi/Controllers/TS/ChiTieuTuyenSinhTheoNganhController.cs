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
    public class ChiTieuTuyenSinhTheoNganhController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChiTieuTuyenSinhTheoNganhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbChiTieuTuyenSinhTheoNganh>>> GetTbChiTieuTuyenSinhTheoNganhs()
        {
            return await _context.TbChiTieuTuyenSinhTheoNganhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbChiTieuTuyenSinhTheoNganh>> GetTbChiTieuTuyenSinhTheoNganh(int id)
        {
            var TbChiTieuTuyenSinhTheoNganh = await _context.TbChiTieuTuyenSinhTheoNganhs.FindAsync(id);

            if (TbChiTieuTuyenSinhTheoNganh == null)
            {
                return NotFound();
            }

            return TbChiTieuTuyenSinhTheoNganh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbChiTieuTuyenSinhTheoNganh(int id, TbChiTieuTuyenSinhTheoNganh TbChiTieuTuyenSinhTheoNganh)
        {
            if (id != TbChiTieuTuyenSinhTheoNganh.IdChiTieuTuyenSinhTheoNganh)
            {
                return BadRequest();
            }

            _context.Entry(TbChiTieuTuyenSinhTheoNganh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbChiTieuTuyenSinhTheoNganhExists(id))
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
        public async Task<ActionResult<TbChiTieuTuyenSinhTheoNganh>> PostTbChiTieuTuyenSinhTheoNganh(TbChiTieuTuyenSinhTheoNganh TbChiTieuTuyenSinhTheoNganh)
        {
            _context.TbChiTieuTuyenSinhTheoNganhs.Add(TbChiTieuTuyenSinhTheoNganh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbChiTieuTuyenSinhTheoNganhExists(TbChiTieuTuyenSinhTheoNganh.IdChiTieuTuyenSinhTheoNganh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbChiTieuTuyenSinhTheoNganh", new { id = TbChiTieuTuyenSinhTheoNganh.IdChiTieuTuyenSinhTheoNganh }, TbChiTieuTuyenSinhTheoNganh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbChiTieuTuyenSinhTheoNganh(int id)
        {
            var TbChiTieuTuyenSinhTheoNganh = await _context.TbChiTieuTuyenSinhTheoNganhs.FindAsync(id);
            if (TbChiTieuTuyenSinhTheoNganh == null)
            {
                return NotFound();
            }

            _context.TbChiTieuTuyenSinhTheoNganhs.Remove(TbChiTieuTuyenSinhTheoNganh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbChiTieuTuyenSinhTheoNganhExists(int id)
        {
            return _context.TbChiTieuTuyenSinhTheoNganhs.Any(e => e.IdChiTieuTuyenSinhTheoNganh == id);
        }
    }
}
