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
    public class NguoiHocVayTinDungController : ControllerBase
    {
        private readonly HemisContext _context;

        public NguoiHocVayTinDungController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNguoiHocVayTinDung>>> GetTbNguoiHocVayTinDungs()
        {
            return await _context.TbNguoiHocVayTinDungs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNguoiHocVayTinDung>> GetTbNguoiHocVayTinDung(int id)
        {
            var TbNguoiHocVayTinDung = await _context.TbNguoiHocVayTinDungs.FindAsync(id);

            if (TbNguoiHocVayTinDung == null)
            {
                return NotFound();
            }

            return TbNguoiHocVayTinDung;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNguoiHocVayTinDung(int id, TbNguoiHocVayTinDung TbNguoiHocVayTinDung)
        {
            if (id != TbNguoiHocVayTinDung.IdNguoiHocVayTinDung)
            {
                return BadRequest();
            }

            _context.Entry(TbNguoiHocVayTinDung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNguoiHocVayTinDungExists(id))
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
        public async Task<ActionResult<TbNguoiHocVayTinDung>> PostTbNguoiHocVayTinDung(TbNguoiHocVayTinDung TbNguoiHocVayTinDung)
        {
            _context.TbNguoiHocVayTinDungs.Add(TbNguoiHocVayTinDung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNguoiHocVayTinDungExists(TbNguoiHocVayTinDung.IdNguoiHocVayTinDung))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNguoiHocVayTinDung", new { id = TbNguoiHocVayTinDung.IdNguoiHocVayTinDung }, TbNguoiHocVayTinDung);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNguoiHocVayTinDung(int id)
        {
            var TbNguoiHocVayTinDung = await _context.TbNguoiHocVayTinDungs.FindAsync(id);
            if (TbNguoiHocVayTinDung == null)
            {
                return NotFound();
            }

            _context.TbNguoiHocVayTinDungs.Remove(TbNguoiHocVayTinDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNguoiHocVayTinDungExists(int id)
        {
            return _context.TbNguoiHocVayTinDungs.Any(e => e.IdNguoiHocVayTinDung == id);
        }
    }
}
