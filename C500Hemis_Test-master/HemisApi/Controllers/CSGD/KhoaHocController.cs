using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSGD
{
    [Route("api/csgd/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public KhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKhoaHoc>>> GetTbKhoaHocs()
        {
            return await _context.TbKhoaHocs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKhoaHoc>> GetTbKhoaHoc(int id)
        {
            var TbKhoaHoc = await _context.TbKhoaHocs.FindAsync(id);

            if (TbKhoaHoc == null)
            {
                return NotFound();
            }

            return TbKhoaHoc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKhoaHoc(int id, TbKhoaHoc TbKhoaHoc)
        {
            if (id != TbKhoaHoc.IdKhoaHoc)
            {
                return BadRequest();
            }

            _context.Entry(TbKhoaHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKhoaHocExists(id))
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
        public async Task<ActionResult<TbKhoaHoc>> PostTbKhoaHoc(TbKhoaHoc TbKhoaHoc)
        {
            _context.TbKhoaHocs.Add(TbKhoaHoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbKhoaHocExists(TbKhoaHoc.IdKhoaHoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbKhoaHoc", new { id = TbKhoaHoc.IdKhoaHoc }, TbKhoaHoc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKhoaHoc(int id)
        {
            var TbKhoaHoc = await _context.TbKhoaHocs.FindAsync(id);
            if (TbKhoaHoc == null)
            {
                return NotFound();
            }

            _context.TbKhoaHocs.Remove(TbKhoaHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKhoaHocExists(int id)
        {
            return _context.TbKhoaHocs.Any(e => e.IdKhoaHoc == id);
        }
    }
}
