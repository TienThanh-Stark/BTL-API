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
    public class DuLieuTrungTuyenController : ControllerBase
    {
        private readonly HemisContext _context;

        public DuLieuTrungTuyenController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDuLieuTrungTuyen>>> GetTbDuLieuTrungTuyens()
        {
            return await _context.TbDuLieuTrungTuyens.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDuLieuTrungTuyen>> GetTbDuLieuTrungTuyen(int id)
        {
            var TbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens.FindAsync(id);

            if (TbDuLieuTrungTuyen == null)
            {
                return NotFound();
            }

            return TbDuLieuTrungTuyen;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDuLieuTrungTuyen(int id, TbDuLieuTrungTuyen TbDuLieuTrungTuyen)
        {
            if (id != TbDuLieuTrungTuyen.IdDuLieuTrungTuyen)
            {
                return BadRequest();
            }

            _context.Entry(TbDuLieuTrungTuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDuLieuTrungTuyenExists(id))
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
        public async Task<ActionResult<TbDuLieuTrungTuyen>> PostTbDuLieuTrungTuyen(TbDuLieuTrungTuyen TbDuLieuTrungTuyen)
        {
            _context.TbDuLieuTrungTuyens.Add(TbDuLieuTrungTuyen);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDuLieuTrungTuyenExists(TbDuLieuTrungTuyen.IdDuLieuTrungTuyen))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDuLieuTrungTuyen", new { id = TbDuLieuTrungTuyen.IdDuLieuTrungTuyen }, TbDuLieuTrungTuyen);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDuLieuTrungTuyen(int id)
        {
            var TbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens.FindAsync(id);
            if (TbDuLieuTrungTuyen == null)
            {
                return NotFound();
            }

            _context.TbDuLieuTrungTuyens.Remove(TbDuLieuTrungTuyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDuLieuTrungTuyenExists(int id)
        {
            return _context.TbDuLieuTrungTuyens.Any(e => e.IdDuLieuTrungTuyen == id);
        }
    }
}
