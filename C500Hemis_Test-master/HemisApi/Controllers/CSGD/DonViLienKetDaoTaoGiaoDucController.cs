using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSGD
{
    [Route("api/csgd/[controller]")]
    [ApiController]
    public class DonViLienKetDaoTaoGiaoDucController : ControllerBase
    {
        private readonly HemisContext _context;

        public DonViLienKetDaoTaoGiaoDucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDonViLienKetDaoTaoGiaoDuc>>> GetTbDonViLienKetDaoTaoGiaoDucs()
        {
            return await _context.TbDonViLienKetDaoTaoGiaoDucs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDonViLienKetDaoTaoGiaoDuc>> GetTbDonViLienKetDaoTaoGiaoDuc(int id)
        {
            var TbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs.FindAsync(id);

            if (TbDonViLienKetDaoTaoGiaoDuc == null)
            {
                return NotFound();
            }

            return TbDonViLienKetDaoTaoGiaoDuc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDonViLienKetDaoTaoGiaoDuc(int id, TbDonViLienKetDaoTaoGiaoDuc TbDonViLienKetDaoTaoGiaoDuc)
        {
            if (id != TbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc)
            {
                return BadRequest();
            }

            _context.Entry(TbDonViLienKetDaoTaoGiaoDuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDonViLienKetDaoTaoGiaoDucExists(id))
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
        public async Task<ActionResult<TbDonViLienKetDaoTaoGiaoDuc>> PostTbDonViLienKetDaoTaoGiaoDuc(TbDonViLienKetDaoTaoGiaoDuc TbDonViLienKetDaoTaoGiaoDuc)
        {
            _context.TbDonViLienKetDaoTaoGiaoDucs.Add(TbDonViLienKetDaoTaoGiaoDuc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDonViLienKetDaoTaoGiaoDucExists(TbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDonViLienKetDaoTaoGiaoDuc", new { id = TbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc }, TbDonViLienKetDaoTaoGiaoDuc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDonViLienKetDaoTaoGiaoDuc(int id)
        {
            var TbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs.FindAsync(id);
            if (TbDonViLienKetDaoTaoGiaoDuc == null)
            {
                return NotFound();
            }

            _context.TbDonViLienKetDaoTaoGiaoDucs.Remove(TbDonViLienKetDaoTaoGiaoDuc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDonViLienKetDaoTaoGiaoDucExists(int id)
        {
            return _context.TbDonViLienKetDaoTaoGiaoDucs.Any(e => e.IdDonViLienKetDaoTaoGiaoDuc == id);
        }
    }
}
