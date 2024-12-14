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
    public class ThongTinViecLamSauTotNghiepController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinViecLamSauTotNghiepController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinViecLamSauTotNghiep>>> GetTbThongTinViecLamSauTotNghieps()
        {
            return await _context.TbThongTinViecLamSauTotNghieps.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinViecLamSauTotNghiep>> GetTbThongTinViecLamSauTotNghiep(int id)
        {
            var TbThongTinViecLamSauTotNghiep = await _context.TbThongTinViecLamSauTotNghieps.FindAsync(id);

            if (TbThongTinViecLamSauTotNghiep == null)
            {
                return NotFound();
            }

            return TbThongTinViecLamSauTotNghiep;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinViecLamSauTotNghiep(int id, TbThongTinViecLamSauTotNghiep TbThongTinViecLamSauTotNghiep)
        {
            if (id != TbThongTinViecLamSauTotNghiep.IdThongTinViecLamSauTotNghiep)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinViecLamSauTotNghiep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinViecLamSauTotNghiepExists(id))
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
        public async Task<ActionResult<TbThongTinViecLamSauTotNghiep>> PostTbThongTinViecLamSauTotNghiep(TbThongTinViecLamSauTotNghiep TbThongTinViecLamSauTotNghiep)
        {
            _context.TbThongTinViecLamSauTotNghieps.Add(TbThongTinViecLamSauTotNghiep);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinViecLamSauTotNghiepExists(TbThongTinViecLamSauTotNghiep.IdThongTinViecLamSauTotNghiep))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinViecLamSauTotNghiep", new { id = TbThongTinViecLamSauTotNghiep.IdThongTinViecLamSauTotNghiep }, TbThongTinViecLamSauTotNghiep);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinViecLamSauTotNghiep(int id)
        {
            var TbThongTinViecLamSauTotNghiep = await _context.TbThongTinViecLamSauTotNghieps.FindAsync(id);
            if (TbThongTinViecLamSauTotNghiep == null)
            {
                return NotFound();
            }

            _context.TbThongTinViecLamSauTotNghieps.Remove(TbThongTinViecLamSauTotNghiep);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinViecLamSauTotNghiepExists(int id)
        {
            return _context.TbThongTinViecLamSauTotNghieps.Any(e => e.IdThongTinViecLamSauTotNghiep == id);
        }
    }
}
