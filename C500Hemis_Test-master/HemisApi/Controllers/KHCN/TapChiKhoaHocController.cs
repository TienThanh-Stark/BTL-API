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
    public class TapChiKhoaHocController : ControllerBase
    {
        private readonly HemisContext _context;

        public TapChiKhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTapChiKhoaHoc>>> GetTbTapChiKhoaHocs()
        {
            return await _context.TbTapChiKhoaHocs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTapChiKhoaHoc>> GetTbTapChiKhoaHoc(int id)
        {
            var TbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs.FindAsync(id);

            if (TbTapChiKhoaHoc == null)
            {
                return NotFound();
            }

            return TbTapChiKhoaHoc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTapChiKhoaHoc(int id, TbTapChiKhoaHoc TbTapChiKhoaHoc)
        {
            if (id != TbTapChiKhoaHoc.IdTapChiKhoaHoc)
            {
                return BadRequest();
            }

            _context.Entry(TbTapChiKhoaHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTapChiKhoaHocExists(id))
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
        public async Task<ActionResult<TbTapChiKhoaHoc>> PostTbTapChiKhoaHoc(TbTapChiKhoaHoc TbTapChiKhoaHoc)
        {
            _context.TbTapChiKhoaHocs.Add(TbTapChiKhoaHoc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbTapChiKhoaHocExists(TbTapChiKhoaHoc.IdTapChiKhoaHoc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbTapChiKhoaHoc", new { id = TbTapChiKhoaHoc.IdTapChiKhoaHoc }, TbTapChiKhoaHoc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbTapChiKhoaHoc(int id)
        {
            var TbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs.FindAsync(id);
            if (TbTapChiKhoaHoc == null)
            {
                return NotFound();
            }

            _context.TbTapChiKhoaHocs.Remove(TbTapChiKhoaHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbTapChiKhoaHocExists(int id)
        {
            return _context.TbTapChiKhoaHocs.Any(e => e.IdTapChiKhoaHoc == id);
        }
    }
}
