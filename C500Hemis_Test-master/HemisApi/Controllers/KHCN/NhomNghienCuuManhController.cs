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
    public class NhomNghienCuuManhController : ControllerBase
    {
        private readonly HemisContext _context;

        public NhomNghienCuuManhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNhomNghienCuuManh>>> GetTbNhomNghienCuuManhs()
        {
            return await _context.TbNhomNghienCuuManhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNhomNghienCuuManh>> GetTbNhomNghienCuuManh(int id)
        {
            var TbNhomNghienCuuManh = await _context.TbNhomNghienCuuManhs.FindAsync(id);

            if (TbNhomNghienCuuManh == null)
            {
                return NotFound();
            }

            return TbNhomNghienCuuManh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNhomNghienCuuManh(int id, TbNhomNghienCuuManh TbNhomNghienCuuManh)
        {
            if (id != TbNhomNghienCuuManh.IdNhomNghienCuuManh)
            {
                return BadRequest();
            }

            _context.Entry(TbNhomNghienCuuManh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNhomNghienCuuManhExists(id))
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
        public async Task<ActionResult<TbNhomNghienCuuManh>> PostTbNhomNghienCuuManh(TbNhomNghienCuuManh TbNhomNghienCuuManh)
        {
            _context.TbNhomNghienCuuManhs.Add(TbNhomNghienCuuManh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNhomNghienCuuManhExists(TbNhomNghienCuuManh.IdNhomNghienCuuManh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNhomNghienCuuManh", new { id = TbNhomNghienCuuManh.IdNhomNghienCuuManh }, TbNhomNghienCuuManh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNhomNghienCuuManh(int id)
        {
            var TbNhomNghienCuuManh = await _context.TbNhomNghienCuuManhs.FindAsync(id);
            if (TbNhomNghienCuuManh == null)
            {
                return NotFound();
            }

            _context.TbNhomNghienCuuManhs.Remove(TbNhomNghienCuuManh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNhomNghienCuuManhExists(int id)
        {
            return _context.TbNhomNghienCuuManhs.Any(e => e.IdNhomNghienCuuManh == id);
        }
    }
}
