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
    public class NamApDungChuongTrinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public NamApDungChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNamApDungChuongTrinh>>> GetTbNamApDungChuongTrinhs()
        {
            return await _context.TbNamApDungChuongTrinhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNamApDungChuongTrinh>> GetTbNamApDungChuongTrinh(int id)
        {
            var TbNamApDungChuongTrinh = await _context.TbNamApDungChuongTrinhs.FindAsync(id);

            if (TbNamApDungChuongTrinh == null)
            {
                return NotFound();
            }

            return TbNamApDungChuongTrinh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNamApDungChuongTrinh(int id, TbNamApDungChuongTrinh TbNamApDungChuongTrinh)
        {
            if (id != TbNamApDungChuongTrinh.IdNamApDungChuongTrinh)
            {
                return BadRequest();
            }

            _context.Entry(TbNamApDungChuongTrinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNamApDungChuongTrinhExists(id))
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
        public async Task<ActionResult<TbNamApDungChuongTrinh>> PostTbNamApDungChuongTrinh(TbNamApDungChuongTrinh TbNamApDungChuongTrinh)
        {
            _context.TbNamApDungChuongTrinhs.Add(TbNamApDungChuongTrinh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNamApDungChuongTrinhExists(TbNamApDungChuongTrinh.IdNamApDungChuongTrinh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNamApDungChuongTrinh", new { id = TbNamApDungChuongTrinh.IdNamApDungChuongTrinh }, TbNamApDungChuongTrinh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNamApDungChuongTrinh(int id)
        {
            var TbNamApDungChuongTrinh = await _context.TbNamApDungChuongTrinhs.FindAsync(id);
            if (TbNamApDungChuongTrinh == null)
            {
                return NotFound();
            }

            _context.TbNamApDungChuongTrinhs.Remove(TbNamApDungChuongTrinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNamApDungChuongTrinhExists(int id)
        {
            return _context.TbNamApDungChuongTrinhs.Any(e => e.IdNamApDungChuongTrinh == id);
        }
    }
}
