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
    public class ThongTinKiemDinhCuaChuongTrinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinKiemDinhCuaChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinKiemDinhCuaChuongTrinh>>> GetTbThongTinKiemDinhCuaChuongTrinhs()
        {
            return await _context.TbThongTinKiemDinhCuaChuongTrinhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinKiemDinhCuaChuongTrinh>> GetTbThongTinKiemDinhCuaChuongTrinh(int id)
        {
            var TbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs.FindAsync(id);

            if (TbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }

            return TbThongTinKiemDinhCuaChuongTrinh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinKiemDinhCuaChuongTrinh(int id, TbThongTinKiemDinhCuaChuongTrinh TbThongTinKiemDinhCuaChuongTrinh)
        {
            if (id != TbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinKiemDinhCuaChuongTrinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinKiemDinhCuaChuongTrinhExists(id))
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
        public async Task<ActionResult<TbThongTinKiemDinhCuaChuongTrinh>> PostTbThongTinKiemDinhCuaChuongTrinh(TbThongTinKiemDinhCuaChuongTrinh TbThongTinKiemDinhCuaChuongTrinh)
        {
            _context.TbThongTinKiemDinhCuaChuongTrinhs.Add(TbThongTinKiemDinhCuaChuongTrinh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinKiemDinhCuaChuongTrinhExists(TbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinKiemDinhCuaChuongTrinh", new { id = TbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh }, TbThongTinKiemDinhCuaChuongTrinh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinKiemDinhCuaChuongTrinh(int id)
        {
            var TbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs.FindAsync(id);
            if (TbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }

            _context.TbThongTinKiemDinhCuaChuongTrinhs.Remove(TbThongTinKiemDinhCuaChuongTrinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinKiemDinhCuaChuongTrinhExists(int id)
        {
            return _context.TbThongTinKiemDinhCuaChuongTrinhs.Any(e => e.IdThongTinKiemDinhCuaChuongTrinh == id);
        }
    }
}
