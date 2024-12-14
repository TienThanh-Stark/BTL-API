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
    public class LoaiHinhDaoTaoKhacDuocChoPhepMoNganhController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiHinhDaoTaoKhacDuocChoPhepMoNganhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>>> GetTbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs()
        {
            return await _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>> GetTbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh(int id)
        {
            var TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh = await _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.FindAsync(id);

            if (TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == null)
            {
                return NotFound();
            }

            return TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh(int id, TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh)
        {
            if (id != TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh)
            {
                return BadRequest();
            }

            _context.Entry(TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhExists(id))
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
        public async Task<ActionResult<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>> PostTbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh(TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh)
        {
            _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.Add(TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhExists(TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh", new { id = TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh }, TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh(int id)
        {
            var TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh = await _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.FindAsync(id);
            if (TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == null)
            {
                return NotFound();
            }

            _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.Remove(TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhExists(int id)
        {
            return _context.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs.Any(e => e.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh == id);
        }
    }
}
