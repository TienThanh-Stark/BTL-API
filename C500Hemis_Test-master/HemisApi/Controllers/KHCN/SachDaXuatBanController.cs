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
    public class SachDaXuatBanController : ControllerBase
    {
        private readonly HemisContext _context;

        public SachDaXuatBanController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSachDaXuatBan>>> GetTbSachDaXuatBans()
        {
            return await _context.TbSachDaXuatBans.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSachDaXuatBan>> GetTbSachDaXuatBan(int id)
        {
            var TbSachDaXuatBan = await _context.TbSachDaXuatBans.FindAsync(id);

            if (TbSachDaXuatBan == null)
            {
                return NotFound();
            }

            return TbSachDaXuatBan;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSachDaXuatBan(int id, TbSachDaXuatBan TbSachDaXuatBan)
        {
            if (id != TbSachDaXuatBan.IdSachDaXuatBan)
            {
                return BadRequest();
            }

            _context.Entry(TbSachDaXuatBan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSachDaXuatBanExists(id))
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
        public async Task<ActionResult<TbSachDaXuatBan>> PostTbSachDaXuatBan(TbSachDaXuatBan TbSachDaXuatBan)
        {
            _context.TbSachDaXuatBans.Add(TbSachDaXuatBan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbSachDaXuatBanExists(TbSachDaXuatBan.IdSachDaXuatBan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbSachDaXuatBan", new { id = TbSachDaXuatBan.IdSachDaXuatBan }, TbSachDaXuatBan);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbSachDaXuatBan(int id)
        {
            var TbSachDaXuatBan = await _context.TbSachDaXuatBans.FindAsync(id);
            if (TbSachDaXuatBan == null)
            {
                return NotFound();
            }

            _context.TbSachDaXuatBans.Remove(TbSachDaXuatBan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbSachDaXuatBanExists(int id)
        {
            return _context.TbSachDaXuatBans.Any(e => e.IdSachDaXuatBan == id);
        }
    }
}
