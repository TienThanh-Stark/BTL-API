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
    public class DoiTuongThamGiaController : ControllerBase
    {
        private readonly HemisContext _context;

        public DoiTuongThamGiaController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDoiTuongThamGium>>> GetTbDoiTuongThamGia()
        {
            return await _context.TbDoiTuongThamGia.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDoiTuongThamGium>> GetTbDoiTuongThamGium(int id)
        {
            var TbDoiTuongThamGium = await _context.TbDoiTuongThamGia.FindAsync(id);

            if (TbDoiTuongThamGium == null)
            {
                return NotFound();
            }

            return TbDoiTuongThamGium;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDoiTuongThamGium(int id, TbDoiTuongThamGium TbDoiTuongThamGium)
        {
            if (id != TbDoiTuongThamGium.IdDoiTuongThamGia)
            {
                return BadRequest();
            }

            _context.Entry(TbDoiTuongThamGium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDoiTuongThamGiumExists(id))
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
        public async Task<ActionResult<TbDoiTuongThamGium>> PostTbDoiTuongThamGium(TbDoiTuongThamGium TbDoiTuongThamGium)
        {
            _context.TbDoiTuongThamGia.Add(TbDoiTuongThamGium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDoiTuongThamGiumExists(TbDoiTuongThamGium.IdDoiTuongThamGia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDoiTuongThamGium", new { id = TbDoiTuongThamGium.IdDoiTuongThamGia }, TbDoiTuongThamGium);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDoiTuongThamGium(int id)
        {
            var TbDoiTuongThamGium = await _context.TbDoiTuongThamGia.FindAsync(id);
            if (TbDoiTuongThamGium == null)
            {
                return NotFound();
            }

            _context.TbDoiTuongThamGia.Remove(TbDoiTuongThamGium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDoiTuongThamGiumExists(int id)
        {
            return _context.TbDoiTuongThamGia.Any(e => e.IdDoiTuongThamGia == id);
        }
    }
}
