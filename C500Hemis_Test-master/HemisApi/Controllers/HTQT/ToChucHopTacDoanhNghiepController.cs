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
    public class ToChucHopTacDoanhNghiepController : ControllerBase
    {
        private readonly HemisContext _context;

        public ToChucHopTacDoanhNghiepController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbToChucHopTacDoanhNghiep>>> GetTbToChucHopTacDoanhNghieps()
        {
            return await _context.TbToChucHopTacDoanhNghieps.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbToChucHopTacDoanhNghiep>> GetTbToChucHopTacDoanhNghiep(int id)
        {
            var TbToChucHopTacDoanhNghiep = await _context.TbToChucHopTacDoanhNghieps.FindAsync(id);

            if (TbToChucHopTacDoanhNghiep == null)
            {
                return NotFound();
            }

            return TbToChucHopTacDoanhNghiep;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbToChucHopTacDoanhNghiep(int id, TbToChucHopTacDoanhNghiep TbToChucHopTacDoanhNghiep)
        {
            if (id != TbToChucHopTacDoanhNghiep.IdToChucHopTacDoanhNghiep)
            {
                return BadRequest();
            }

            _context.Entry(TbToChucHopTacDoanhNghiep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbToChucHopTacDoanhNghiepExists(id))
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
        public async Task<ActionResult<TbToChucHopTacDoanhNghiep>> PostTbToChucHopTacDoanhNghiep(TbToChucHopTacDoanhNghiep TbToChucHopTacDoanhNghiep)
        {
            _context.TbToChucHopTacDoanhNghieps.Add(TbToChucHopTacDoanhNghiep);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbToChucHopTacDoanhNghiepExists(TbToChucHopTacDoanhNghiep.IdToChucHopTacDoanhNghiep))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbToChucHopTacDoanhNghiep", new { id = TbToChucHopTacDoanhNghiep.IdToChucHopTacDoanhNghiep }, TbToChucHopTacDoanhNghiep);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbToChucHopTacDoanhNghiep(int id)
        {
            var TbToChucHopTacDoanhNghiep = await _context.TbToChucHopTacDoanhNghieps.FindAsync(id);
            if (TbToChucHopTacDoanhNghiep == null)
            {
                return NotFound();
            }

            _context.TbToChucHopTacDoanhNghieps.Remove(TbToChucHopTacDoanhNghiep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbToChucHopTacDoanhNghiepExists(int id)
        {
            return _context.TbToChucHopTacDoanhNghieps.Any(e => e.IdToChucHopTacDoanhNghiep == id);
        }
    }
}
