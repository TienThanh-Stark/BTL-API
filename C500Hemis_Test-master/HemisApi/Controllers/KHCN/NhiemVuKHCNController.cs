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
    public class NhiemVuKHCNController : ControllerBase
    {
        private readonly HemisContext _context;

        public NhiemVuKHCNController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNhiemVuKhcn>>> GetTbNhiemVuKhcns()
        {
            return await _context.TbNhiemVuKhcns.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNhiemVuKhcn>> GetTbNhiemVuKhcn(int id)
        {
            var TbNhiemVuKhcn = await _context.TbNhiemVuKhcns.FindAsync(id);

            if (TbNhiemVuKhcn == null)
            {
                return NotFound();
            }

            return TbNhiemVuKhcn;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNhiemVuKhcn(int id, TbNhiemVuKhcn TbNhiemVuKhcn)
        {
            if (id != TbNhiemVuKhcn.IdNhiemVuKhcn)
            {
                return BadRequest();
            }

            _context.Entry(TbNhiemVuKhcn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNhiemVuKhcnExists(id))
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
        public async Task<ActionResult<TbNhiemVuKhcn>> PostTbNhiemVuKhcn(TbNhiemVuKhcn TbNhiemVuKhcn)
        {
            _context.TbNhiemVuKhcns.Add(TbNhiemVuKhcn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNhiemVuKhcnExists(TbNhiemVuKhcn.IdNhiemVuKhcn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNhiemVuKhcn", new { id = TbNhiemVuKhcn.IdNhiemVuKhcn }, TbNhiemVuKhcn);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNhiemVuKhcn(int id)
        {
            var TbNhiemVuKhcn = await _context.TbNhiemVuKhcns.FindAsync(id);
            if (TbNhiemVuKhcn == null)
            {
                return NotFound();
            }

            _context.TbNhiemVuKhcns.Remove(TbNhiemVuKhcn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNhiemVuKhcnExists(int id)
        {
            return _context.TbNhiemVuKhcns.Any(e => e.IdNhiemVuKhcn == id);
        }
    }
}
