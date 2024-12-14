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
    public class VanBanTuChuController : ControllerBase
    {
        private readonly HemisContext _context;

        public VanBanTuChuController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbVanBanTuChu>>> GetTbVanBanTuChus()
        {
            return await _context.TbVanBanTuChus.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbVanBanTuChu>> GetTbVanBanTuChu(int id)
        {
            var TbVanBanTuChu = await _context.TbVanBanTuChus.FindAsync(id);

            if (TbVanBanTuChu == null)
            {
                return NotFound();
            }

            return TbVanBanTuChu;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbVanBanTuChu(int id, TbVanBanTuChu TbVanBanTuChu)
        {
            if (id != TbVanBanTuChu.IdVanBanTuChu)
            {
                return BadRequest();
            }

            _context.Entry(TbVanBanTuChu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbVanBanTuChuExists(id))
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
        public async Task<ActionResult<TbVanBanTuChu>> PostTbVanBanTuChu(TbVanBanTuChu TbVanBanTuChu)
        {
            _context.TbVanBanTuChus.Add(TbVanBanTuChu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbVanBanTuChuExists(TbVanBanTuChu.IdVanBanTuChu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbVanBanTuChu", new { id = TbVanBanTuChu.IdVanBanTuChu }, TbVanBanTuChu);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbVanBanTuChu(int id)
        {
            var TbVanBanTuChu = await _context.TbVanBanTuChus.FindAsync(id);
            if (TbVanBanTuChu == null)
            {
                return NotFound();
            }

            _context.TbVanBanTuChus.Remove(TbVanBanTuChu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbVanBanTuChuExists(int id)
        {
            return _context.TbVanBanTuChus.Any(e => e.IdVanBanTuChu == id);
        }
    }
}
