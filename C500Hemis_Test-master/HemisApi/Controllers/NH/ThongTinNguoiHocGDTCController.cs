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
    public class ThongTinNguoiHocGDTCController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinNguoiHocGDTCController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinNguoiHocGdtc>>> GetTbThongTinNguoiHocGdtcs()
        {
            return await _context.TbThongTinNguoiHocGdtcs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinNguoiHocGdtc>> GetTbThongTinNguoiHocGdtc(int id)
        {
            var TbThongTinNguoiHocGdtc = await _context.TbThongTinNguoiHocGdtcs.FindAsync(id);

            if (TbThongTinNguoiHocGdtc == null)
            {
                return NotFound();
            }

            return TbThongTinNguoiHocGdtc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinNguoiHocGdtc(int id, TbThongTinNguoiHocGdtc TbThongTinNguoiHocGdtc)
        {
            if (id != TbThongTinNguoiHocGdtc.IdThongTinNguoiHocGdtc)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinNguoiHocGdtc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinNguoiHocGdtcExists(id))
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
        public async Task<ActionResult<TbThongTinNguoiHocGdtc>> PostTbThongTinNguoiHocGdtc(TbThongTinNguoiHocGdtc TbThongTinNguoiHocGdtc)
        {
            _context.TbThongTinNguoiHocGdtcs.Add(TbThongTinNguoiHocGdtc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinNguoiHocGdtcExists(TbThongTinNguoiHocGdtc.IdThongTinNguoiHocGdtc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinNguoiHocGdtc", new { id = TbThongTinNguoiHocGdtc.IdThongTinNguoiHocGdtc }, TbThongTinNguoiHocGdtc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinNguoiHocGdtc(int id)
        {
            var TbThongTinNguoiHocGdtc = await _context.TbThongTinNguoiHocGdtcs.FindAsync(id);
            if (TbThongTinNguoiHocGdtc == null)
            {
                return NotFound();
            }

            _context.TbThongTinNguoiHocGdtcs.Remove(TbThongTinNguoiHocGdtc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinNguoiHocGdtcExists(int id)
        {
            return _context.TbThongTinNguoiHocGdtcs.Any(e => e.IdThongTinNguoiHocGdtc == id);
        }
    }
}
