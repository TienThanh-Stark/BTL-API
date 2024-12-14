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
    public class ThongTinHocBongController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinHocBongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinHocBong>>> GetTbThongTinHocBongs()
        {
            return await _context.TbThongTinHocBongs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinHocBong>> GetTbThongTinHocBong(int id)
        {
            var TbThongTinHocBong = await _context.TbThongTinHocBongs.FindAsync(id);

            if (TbThongTinHocBong == null)
            {
                return NotFound();
            }

            return TbThongTinHocBong;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinHocBong(int id, TbThongTinHocBong TbThongTinHocBong)
        {
            if (id != TbThongTinHocBong.IdThongTinHocBong)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinHocBong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinHocBongExists(id))
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
        public async Task<ActionResult<TbThongTinHocBong>> PostTbThongTinHocBong(TbThongTinHocBong TbThongTinHocBong)
        {
            _context.TbThongTinHocBongs.Add(TbThongTinHocBong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinHocBongExists(TbThongTinHocBong.IdThongTinHocBong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinHocBong", new { id = TbThongTinHocBong.IdThongTinHocBong }, TbThongTinHocBong);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinHocBong(int id)
        {
            var TbThongTinHocBong = await _context.TbThongTinHocBongs.FindAsync(id);
            if (TbThongTinHocBong == null)
            {
                return NotFound();
            }

            _context.TbThongTinHocBongs.Remove(TbThongTinHocBong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinHocBongExists(int id)
        {
            return _context.TbThongTinHocBongs.Any(e => e.IdThongTinHocBong == id);
        }
    }
}
