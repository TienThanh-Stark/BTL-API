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
    public class DoanhNghiepKHCNController : ControllerBase
    {
        private readonly HemisContext _context;

        public DoanhNghiepKHCNController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDoanhNghiepKhcn>>> GetTbDoanhNghiepKhcns()
        {
            return await _context.TbDoanhNghiepKhcns.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDoanhNghiepKhcn>> GetTbDoanhNghiepKhcn(int id)
        {
            var TbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns.FindAsync(id);

            if (TbDoanhNghiepKhcn == null)
            {
                return NotFound();
            }

            return TbDoanhNghiepKhcn;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDoanhNghiepKhcn(int id, TbDoanhNghiepKhcn TbDoanhNghiepKhcn)
        {
            if (id != TbDoanhNghiepKhcn.IdDoanhNghiepKhcn)
            {
                return BadRequest();
            }

            _context.Entry(TbDoanhNghiepKhcn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDoanhNghiepKhcnExists(id))
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
        public async Task<ActionResult<TbDoanhNghiepKhcn>> PostTbDoanhNghiepKhcn(TbDoanhNghiepKhcn TbDoanhNghiepKhcn)
        {
            _context.TbDoanhNghiepKhcns.Add(TbDoanhNghiepKhcn);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDoanhNghiepKhcnExists(TbDoanhNghiepKhcn.IdDoanhNghiepKhcn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDoanhNghiepKhcn", new { id = TbDoanhNghiepKhcn.IdDoanhNghiepKhcn }, TbDoanhNghiepKhcn);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDoanhNghiepKhcn(int id)
        {
            var TbDoanhNghiepKhcn = await _context.TbDoanhNghiepKhcns.FindAsync(id);
            if (TbDoanhNghiepKhcn == null)
            {
                return NotFound();
            }

            _context.TbDoanhNghiepKhcns.Remove(TbDoanhNghiepKhcn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDoanhNghiepKhcnExists(int id)
        {
            return _context.TbDoanhNghiepKhcns.Any(e => e.IdDoanhNghiepKhcn == id);
        }
    }
}
