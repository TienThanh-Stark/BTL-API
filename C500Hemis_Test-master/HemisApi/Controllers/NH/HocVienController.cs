using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.NH
{
    [Route("api/nh/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly HemisContext _context;

        public HocVienController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHocVien>>> GetTbHocViens()
        {
            return await _context.TbHocViens.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHocVien>> GetTbHocVien(int id)
        {
            var TbHocVien = await _context.TbHocViens.FindAsync(id);

            if (TbHocVien == null)
            {
                return NotFound();
            }

            return TbHocVien;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHocVien(int id, TbHocVien TbHocVien)
        {
            if (id != TbHocVien.IdHocVien)
            {
                return BadRequest();
            }

            _context.Entry(TbHocVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHocVienExists(id))
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
        public async Task<ActionResult<TbHocVien>> PostTbHocVien(TbHocVien TbHocVien)
        {
            _context.TbHocViens.Add(TbHocVien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbHocVienExists(TbHocVien.IdHocVien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbHocVien", new { id = TbHocVien.IdHocVien }, TbHocVien);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbHocVien(int id)
        {
            var TbHocVien = await _context.TbHocViens.FindAsync(id);
            if (TbHocVien == null)
            {
                return NotFound();
            }

            _context.TbHocViens.Remove(TbHocVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbHocVienExists(int id)
        {
            return _context.TbHocViens.Any(e => e.IdHocVien == id);
        }
    }
}
