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
    public class ToChucKiemDinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public ToChucKiemDinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbToChucKiemDinh>>> GetTbToChucKiemDinhs()
        {
            return await _context.TbToChucKiemDinhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbToChucKiemDinh>> GetTbToChucKiemDinh(int id)
        {
            var TbToChucKiemDinh = await _context.TbToChucKiemDinhs.FindAsync(id);

            if (TbToChucKiemDinh == null)
            {
                return NotFound();
            }

            return TbToChucKiemDinh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbToChucKiemDinh(int id, TbToChucKiemDinh TbToChucKiemDinh)
        {
            if (id != TbToChucKiemDinh.IdToChucKiemDinhCsdg)
            {
                return BadRequest();
            }

            _context.Entry(TbToChucKiemDinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbToChucKiemDinhExists(id))
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
        public async Task<ActionResult<TbToChucKiemDinh>> PostTbToChucKiemDinh(TbToChucKiemDinh TbToChucKiemDinh)
        {
            _context.TbToChucKiemDinhs.Add(TbToChucKiemDinh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbToChucKiemDinhExists(TbToChucKiemDinh.IdToChucKiemDinhCsdg))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbToChucKiemDinh", new { id = TbToChucKiemDinh.IdToChucKiemDinhCsdg }, TbToChucKiemDinh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbToChucKiemDinh(int id)
        {
            var TbToChucKiemDinh = await _context.TbToChucKiemDinhs.FindAsync(id);
            if (TbToChucKiemDinh == null)
            {
                return NotFound();
            }

            _context.TbToChucKiemDinhs.Remove(TbToChucKiemDinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbToChucKiemDinhExists(int id)
        {
            return _context.TbToChucKiemDinhs.Any(e => e.IdToChucKiemDinhCsdg == id);
        }
    }
}
