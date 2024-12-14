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
    public class DoanCongTacController : ControllerBase
    {
        private readonly HemisContext _context;

        public DoanCongTacController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDoanCongTac>>> GetTbDoanCongTacs()
        {
            return await _context.TbDoanCongTacs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDoanCongTac>> GetTbDoanCongTac(int id)
        {
            var TbDoanCongTac = await _context.TbDoanCongTacs.FindAsync(id);

            if (TbDoanCongTac == null)
            {
                return NotFound();
            }

            return TbDoanCongTac;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDoanCongTac(int id, TbDoanCongTac TbDoanCongTac)
        {
            if (id != TbDoanCongTac.IdDoanCongTac)
            {
                return BadRequest();
            }

            _context.Entry(TbDoanCongTac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDoanCongTacExists(id))
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
        public async Task<ActionResult<TbDoanCongTac>> PostTbDoanCongTac(TbDoanCongTac TbDoanCongTac)
        {
            _context.TbDoanCongTacs.Add(TbDoanCongTac);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDoanCongTacExists(TbDoanCongTac.IdDoanCongTac))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDoanCongTac", new { id = TbDoanCongTac.IdDoanCongTac }, TbDoanCongTac);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDoanCongTac(int id)
        {
            var TbDoanCongTac = await _context.TbDoanCongTacs.FindAsync(id);
            if (TbDoanCongTac == null)
            {
                return NotFound();
            }

            _context.TbDoanCongTacs.Remove(TbDoanCongTac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDoanCongTacExists(int id)
        {
            return _context.TbDoanCongTacs.Any(e => e.IdDoanCongTac == id);
        }
    }
}
