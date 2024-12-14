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
    public class ThongTinViPhamController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinViPhamController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinViPham>>> GetTbThongTinViPhams()
        {
            return await _context.TbThongTinViPhams.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinViPham>> GetTbThongTinViPham(int id)
        {
            var TbThongTinViPham = await _context.TbThongTinViPhams.FindAsync(id);

            if (TbThongTinViPham == null)
            {
                return NotFound();
            }

            return TbThongTinViPham;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinViPham(int id, TbThongTinViPham TbThongTinViPham)
        {
            if (id != TbThongTinViPham.IdThongTinViPham)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinViPham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinViPhamExists(id))
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
        public async Task<ActionResult<TbThongTinViPham>> PostTbThongTinViPham(TbThongTinViPham TbThongTinViPham)
        {
            _context.TbThongTinViPhams.Add(TbThongTinViPham);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinViPhamExists(TbThongTinViPham.IdThongTinViPham))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinViPham", new { id = TbThongTinViPham.IdThongTinViPham }, TbThongTinViPham);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinViPham(int id)
        {
            var TbThongTinViPham = await _context.TbThongTinViPhams.FindAsync(id);
            if (TbThongTinViPham == null)
            {
                return NotFound();
            }

            _context.TbThongTinViPhams.Remove(TbThongTinViPham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinViPhamExists(int id)
        {
            return _context.TbThongTinViPhams.Any(e => e.IdThongTinViPham == id);
        }
    }
}
