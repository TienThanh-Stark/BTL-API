using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.TCTS
{
    [Route("api/tcts/[controller]")]
    [ApiController]
    public class TaiSanDonViController : ControllerBase
    {
        private readonly HemisContext _context;

        public TaiSanDonViController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTaiSanDonVi>>> GetTbTaiSanDonVis()
        {
            return await _context.TbTaiSanDonVis.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTaiSanDonVi>> GetTbTaiSanDonVi(int id)
        {
            var TbTaiSanDonVi = await _context.TbTaiSanDonVis.FindAsync(id);

            if (TbTaiSanDonVi == null)
            {
                return NotFound();
            }

            return TbTaiSanDonVi;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTaiSanDonVi(int id, TbTaiSanDonVi TbTaiSanDonVi)
        {
            if (id != TbTaiSanDonVi.IdTaiSanDonVi)
            {
                return BadRequest();
            }

            _context.Entry(TbTaiSanDonVi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTaiSanDonViExists(id))
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
        public async Task<ActionResult<TbTaiSanDonVi>> PostTbTaiSanDonVi(TbTaiSanDonVi TbTaiSanDonVi)
        {
            _context.TbTaiSanDonVis.Add(TbTaiSanDonVi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbTaiSanDonViExists(TbTaiSanDonVi.IdTaiSanDonVi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbTaiSanDonVi", new { id = TbTaiSanDonVi.IdTaiSanDonVi }, TbTaiSanDonVi);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbTaiSanDonVi(int id)
        {
            var TbTaiSanDonVi = await _context.TbTaiSanDonVis.FindAsync(id);
            if (TbTaiSanDonVi == null)
            {
                return NotFound();
            }

            _context.TbTaiSanDonVis.Remove(TbTaiSanDonVi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbTaiSanDonViExists(int id)
        {
            return _context.TbTaiSanDonVis.Any(e => e.IdTaiSanDonVi == id);
        }
    }
}
