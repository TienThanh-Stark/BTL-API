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
    public class CoCauToChucController : ControllerBase
    {
        private readonly HemisContext _context;

        public CoCauToChucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCoCauToChuc>>> GetTbCoCauToChucs()
        {
            return await _context.TbCoCauToChucs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCoCauToChuc>> GetTbCoCauToChuc(int id)
        {
            var TbCoCauToChuc = await _context.TbCoCauToChucs.FindAsync(id);

            if (TbCoCauToChuc == null)
            {
                return NotFound();
            }

            return TbCoCauToChuc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCoCauToChuc(int id, TbCoCauToChuc TbCoCauToChuc)
        {
            if (id != TbCoCauToChuc.IdCoCauToChuc)
            {
                return BadRequest();
            }

            _context.Entry(TbCoCauToChuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCoCauToChucExists(id))
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
        public async Task<ActionResult<TbCoCauToChuc>> PostTbCoCauToChuc(TbCoCauToChuc TbCoCauToChuc)
        {
            _context.TbCoCauToChucs.Add(TbCoCauToChuc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbCoCauToChucExists(TbCoCauToChuc.IdCoCauToChuc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbCoCauToChuc", new { id = TbCoCauToChuc.IdCoCauToChuc }, TbCoCauToChuc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCoCauToChuc(int id)
        {
            var TbCoCauToChuc = await _context.TbCoCauToChucs.FindAsync(id);
            if (TbCoCauToChuc == null)
            {
                return NotFound();
            }

            _context.TbCoCauToChucs.Remove(TbCoCauToChuc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCoCauToChucExists(int id)
        {
            return _context.TbCoCauToChucs.Any(e => e.IdCoCauToChuc == id);
        }
    }
}
