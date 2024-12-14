using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CB
{
    [Route("api/cb/[controller]")]
    [ApiController]
    public class NganhDungTenGiangDayController : ControllerBase
    {
        private readonly HemisContext _context;

        public NganhDungTenGiangDayController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNganhDungTenGiangDay>>> GetTbNganhDungTenGiangDays()
        {
            return await _context.TbNganhDungTenGiangDays.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNganhDungTenGiangDay>> GetTbNganhDungTenGiangDay(int id)
        {
            var TbNganhDungTenGiangDay = await _context.TbNganhDungTenGiangDays.FindAsync(id);

            if (TbNganhDungTenGiangDay == null)
            {
                return NotFound();
            }

            return TbNganhDungTenGiangDay;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNganhDungTenGiangDay(int id, TbNganhDungTenGiangDay TbNganhDungTenGiangDay)
        {
            if (id != TbNganhDungTenGiangDay.IdNganhDungTenGiangDay)
            {
                return BadRequest();
            }

            _context.Entry(TbNganhDungTenGiangDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNganhDungTenGiangDayExists(id))
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
        public async Task<ActionResult<TbNganhDungTenGiangDay>> PostTbNganhDungTenGiangDay(TbNganhDungTenGiangDay TbNganhDungTenGiangDay)
        {
            _context.TbNganhDungTenGiangDays.Add(TbNganhDungTenGiangDay);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNganhDungTenGiangDayExists(TbNganhDungTenGiangDay.IdNganhDungTenGiangDay))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNganhDungTenGiangDay", new { id = TbNganhDungTenGiangDay.IdNganhDungTenGiangDay }, TbNganhDungTenGiangDay);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNganhDungTenGiangDay(int id)
        {
            var TbNganhDungTenGiangDay = await _context.TbNganhDungTenGiangDays.FindAsync(id);
            if (TbNganhDungTenGiangDay == null)
            {
                return NotFound();
            }

            _context.TbNganhDungTenGiangDays.Remove(TbNganhDungTenGiangDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNganhDungTenGiangDayExists(int id)
        {
            return _context.TbNganhDungTenGiangDays.Any(e => e.IdNganhDungTenGiangDay == id);
        }
    }
}
