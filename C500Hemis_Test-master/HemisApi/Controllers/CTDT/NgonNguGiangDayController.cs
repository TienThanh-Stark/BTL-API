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
    public class NgonNguGiangDayController : ControllerBase
    {
        private readonly HemisContext _context;

        public NgonNguGiangDayController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNgonNguGiangDay>>> GetTbNgonNguGiangDays()
        {
            return await _context.TbNgonNguGiangDays.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNgonNguGiangDay>> GetTbNgonNguGiangDay(int id)
        {
            var TbNgonNguGiangDay = await _context.TbNgonNguGiangDays.FindAsync(id);

            if (TbNgonNguGiangDay == null)
            {
                return NotFound();
            }

            return TbNgonNguGiangDay;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNgonNguGiangDay(int id, TbNgonNguGiangDay TbNgonNguGiangDay)
        {
            if (id != TbNgonNguGiangDay.IdNgonNguGiangDay)
            {
                return BadRequest();
            }

            _context.Entry(TbNgonNguGiangDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNgonNguGiangDayExists(id))
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
        public async Task<ActionResult<TbNgonNguGiangDay>> PostTbNgonNguGiangDay(TbNgonNguGiangDay TbNgonNguGiangDay)
        {
            _context.TbNgonNguGiangDays.Add(TbNgonNguGiangDay);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNgonNguGiangDayExists(TbNgonNguGiangDay.IdNgonNguGiangDay))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNgonNguGiangDay", new { id = TbNgonNguGiangDay.IdNgonNguGiangDay }, TbNgonNguGiangDay);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNgonNguGiangDay(int id)
        {
            var TbNgonNguGiangDay = await _context.TbNgonNguGiangDays.FindAsync(id);
            if (TbNgonNguGiangDay == null)
            {
                return NotFound();
            }

            _context.TbNgonNguGiangDays.Remove(TbNgonNguGiangDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNgonNguGiangDayExists(int id)
        {
            return _context.TbNgonNguGiangDays.Any(e => e.IdNgonNguGiangDay == id);
        }
    }
}
