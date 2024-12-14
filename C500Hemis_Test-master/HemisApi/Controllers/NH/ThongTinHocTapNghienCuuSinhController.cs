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
    public class ThongTinHocTapNghienCuuSinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinHocTapNghienCuuSinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinHocTapNghienCuuSinh>>> GetTbThongTinHocTapNghienCuuSinhs()
        {
            return await _context.TbThongTinHocTapNghienCuuSinhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinHocTapNghienCuuSinh>> GetTbThongTinHocTapNghienCuuSinh(int id)
        {
            var TbThongTinHocTapNghienCuuSinh = await _context.TbThongTinHocTapNghienCuuSinhs.FindAsync(id);

            if (TbThongTinHocTapNghienCuuSinh == null)
            {
                return NotFound();
            }

            return TbThongTinHocTapNghienCuuSinh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinHocTapNghienCuuSinh(int id, TbThongTinHocTapNghienCuuSinh TbThongTinHocTapNghienCuuSinh)
        {
            if (id != TbThongTinHocTapNghienCuuSinh.IdThongTinHocTapNghienCuuSinh)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinHocTapNghienCuuSinh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinHocTapNghienCuuSinhExists(id))
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
        public async Task<ActionResult<TbThongTinHocTapNghienCuuSinh>> PostTbThongTinHocTapNghienCuuSinh(TbThongTinHocTapNghienCuuSinh TbThongTinHocTapNghienCuuSinh)
        {
            _context.TbThongTinHocTapNghienCuuSinhs.Add(TbThongTinHocTapNghienCuuSinh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinHocTapNghienCuuSinhExists(TbThongTinHocTapNghienCuuSinh.IdThongTinHocTapNghienCuuSinh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinHocTapNghienCuuSinh", new { id = TbThongTinHocTapNghienCuuSinh.IdThongTinHocTapNghienCuuSinh }, TbThongTinHocTapNghienCuuSinh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinHocTapNghienCuuSinh(int id)
        {
            var TbThongTinHocTapNghienCuuSinh = await _context.TbThongTinHocTapNghienCuuSinhs.FindAsync(id);
            if (TbThongTinHocTapNghienCuuSinh == null)
            {
                return NotFound();
            }

            _context.TbThongTinHocTapNghienCuuSinhs.Remove(TbThongTinHocTapNghienCuuSinh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinHocTapNghienCuuSinhExists(int id)
        {
            return _context.TbThongTinHocTapNghienCuuSinhs.Any(e => e.IdThongTinHocTapNghienCuuSinh == id);
        }
    }
}
