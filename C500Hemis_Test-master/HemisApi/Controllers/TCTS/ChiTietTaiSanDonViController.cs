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
    public class ChiTietTaiSanDonViController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChiTietTaiSanDonViController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbChiTietTaiSanDonVi>>> GetTbChiTietTaiSanDonVis()
        {
            return await _context.TbChiTietTaiSanDonVis.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbChiTietTaiSanDonVi>> GetTbChiTietTaiSanDonVi(int id)
        {
            var TbChiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis.FindAsync(id);

            if (TbChiTietTaiSanDonVi == null)
            {
                return NotFound();
            }

            return TbChiTietTaiSanDonVi;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbChiTietTaiSanDonVi(int id, TbChiTietTaiSanDonVi TbChiTietTaiSanDonVi)
        {
            if (id != TbChiTietTaiSanDonVi.IdChiTietTaiSanDonVi)
            {
                return BadRequest();
            }

            _context.Entry(TbChiTietTaiSanDonVi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbChiTietTaiSanDonViExists(id))
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
        public async Task<ActionResult<TbChiTietTaiSanDonVi>> PostTbChiTietTaiSanDonVi(TbChiTietTaiSanDonVi TbChiTietTaiSanDonVi)
        {
            _context.TbChiTietTaiSanDonVis.Add(TbChiTietTaiSanDonVi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbChiTietTaiSanDonViExists(TbChiTietTaiSanDonVi.IdChiTietTaiSanDonVi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbChiTietTaiSanDonVi", new { id = TbChiTietTaiSanDonVi.IdChiTietTaiSanDonVi }, TbChiTietTaiSanDonVi);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbChiTietTaiSanDonVi(int id)
        {
            var TbChiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis.FindAsync(id);
            if (TbChiTietTaiSanDonVi == null)
            {
                return NotFound();
            }

            _context.TbChiTietTaiSanDonVis.Remove(TbChiTietTaiSanDonVi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbChiTietTaiSanDonViExists(int id)
        {
            return _context.TbChiTietTaiSanDonVis.Any(e => e.IdChiTietTaiSanDonVi == id);
        }
    }
}
