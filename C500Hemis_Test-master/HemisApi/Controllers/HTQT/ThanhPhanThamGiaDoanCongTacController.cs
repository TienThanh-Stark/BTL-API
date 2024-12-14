using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.HTQT
{
    [Route("api/htqt/[controller]")]
    [ApiController]
    public class ThanhPhanThamGiaDoanCongTacController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThanhPhanThamGiaDoanCongTacController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThanhPhanThamGiaDoanCongTac>>> GetTbThanhPhanThamGiaDoanCongTacs()
        {
            return await _context.TbThanhPhanThamGiaDoanCongTacs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThanhPhanThamGiaDoanCongTac>> GetTbThanhPhanThamGiaDoanCongTac(int id)
        {
            var TbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs.FindAsync(id);

            if (TbThanhPhanThamGiaDoanCongTac == null)
            {
                return NotFound();
            }

            return TbThanhPhanThamGiaDoanCongTac;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThanhPhanThamGiaDoanCongTac(int id, TbThanhPhanThamGiaDoanCongTac TbThanhPhanThamGiaDoanCongTac)
        {
            if (id != TbThanhPhanThamGiaDoanCongTac.IdThanhPhanThamGiaDoanCongTac)
            {
                return BadRequest();
            }

            _context.Entry(TbThanhPhanThamGiaDoanCongTac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThanhPhanThamGiaDoanCongTacExists(id))
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
        public async Task<ActionResult<TbThanhPhanThamGiaDoanCongTac>> PostTbThanhPhanThamGiaDoanCongTac(TbThanhPhanThamGiaDoanCongTac TbThanhPhanThamGiaDoanCongTac)
        {
            _context.TbThanhPhanThamGiaDoanCongTacs.Add(TbThanhPhanThamGiaDoanCongTac);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThanhPhanThamGiaDoanCongTacExists(TbThanhPhanThamGiaDoanCongTac.IdThanhPhanThamGiaDoanCongTac))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThanhPhanThamGiaDoanCongTac", new { id = TbThanhPhanThamGiaDoanCongTac.IdThanhPhanThamGiaDoanCongTac }, TbThanhPhanThamGiaDoanCongTac);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThanhPhanThamGiaDoanCongTac(int id)
        {
            var TbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs.FindAsync(id);
            if (TbThanhPhanThamGiaDoanCongTac == null)
            {
                return NotFound();
            }

            _context.TbThanhPhanThamGiaDoanCongTacs.Remove(TbThanhPhanThamGiaDoanCongTac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThanhPhanThamGiaDoanCongTacExists(int id)
        {
            return _context.TbThanhPhanThamGiaDoanCongTacs.Any(e => e.IdThanhPhanThamGiaDoanCongTac == id);
        }
    }
}
