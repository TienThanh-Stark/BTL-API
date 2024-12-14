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
    public class LuuHocSinhSinhVienNNController : ControllerBase
    {
        private readonly HemisContext _context;

        public LuuHocSinhSinhVienNNController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbLuuHocSinhSinhVienNn>>> GetTbLuuHocSinhSinhVienNns()
        {
            return await _context.TbLuuHocSinhSinhVienNns.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbLuuHocSinhSinhVienNn>> GetTbLuuHocSinhSinhVienNn(int id)
        {
            var TbLuuHocSinhSinhVienNn = await _context.TbLuuHocSinhSinhVienNns.FindAsync(id);

            if (TbLuuHocSinhSinhVienNn == null)
            {
                return NotFound();
            }

            return TbLuuHocSinhSinhVienNn;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbLuuHocSinhSinhVienNn(int id, TbLuuHocSinhSinhVienNn TbLuuHocSinhSinhVienNn)
        {
            if (id != TbLuuHocSinhSinhVienNn.IdLuuHocSinhSinhVienNn)
            {
                return BadRequest();
            }

            _context.Entry(TbLuuHocSinhSinhVienNn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbLuuHocSinhSinhVienNnExists(id))
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
        public async Task<ActionResult<TbLuuHocSinhSinhVienNn>> PostTbLuuHocSinhSinhVienNn(TbLuuHocSinhSinhVienNn TbLuuHocSinhSinhVienNn)
        {
            _context.TbLuuHocSinhSinhVienNns.Add(TbLuuHocSinhSinhVienNn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbLuuHocSinhSinhVienNnExists(TbLuuHocSinhSinhVienNn.IdLuuHocSinhSinhVienNn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbLuuHocSinhSinhVienNn", new { id = TbLuuHocSinhSinhVienNn.IdLuuHocSinhSinhVienNn }, TbLuuHocSinhSinhVienNn);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbLuuHocSinhSinhVienNn(int id)
        {
            var TbLuuHocSinhSinhVienNn = await _context.TbLuuHocSinhSinhVienNns.FindAsync(id);
            if (TbLuuHocSinhSinhVienNn == null)
            {
                return NotFound();
            }

            _context.TbLuuHocSinhSinhVienNns.Remove(TbLuuHocSinhSinhVienNn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbLuuHocSinhSinhVienNnExists(int id)
        {
            return _context.TbLuuHocSinhSinhVienNns.Any(e => e.IdLuuHocSinhSinhVienNn == id);
        }
    }
}
