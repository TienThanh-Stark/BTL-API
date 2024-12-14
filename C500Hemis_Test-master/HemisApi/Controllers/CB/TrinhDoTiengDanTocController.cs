using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CB
{
    [Route("api/cb/[controller]")]
    [ApiController]
    public class TrinhDoTiengDanTocController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrinhDoTiengDanTocController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTrinhDoTiengDanToc>>> GetTbTrinhDoTiengDanTocs()
        {
            return await _context.TbTrinhDoTiengDanTocs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTrinhDoTiengDanToc>> GetTbTrinhDoTiengDanToc(int id)
        {
            var TbTrinhDoTiengDanToc = await _context.TbTrinhDoTiengDanTocs.FindAsync(id);

            if (TbTrinhDoTiengDanToc == null)
            {
                return NotFound();
            }

            return TbTrinhDoTiengDanToc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTrinhDoTiengDanToc(int id, TbTrinhDoTiengDanToc TbTrinhDoTiengDanToc)
        {
            if (id != TbTrinhDoTiengDanToc.IdTrinhDoTiengDanToc)
            {
                return BadRequest();
            }

            _context.Entry(TbTrinhDoTiengDanToc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTrinhDoTiengDanTocExists(id))
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
        public async Task<ActionResult<TbTrinhDoTiengDanToc>> PostTbTrinhDoTiengDanToc(TbTrinhDoTiengDanToc TbTrinhDoTiengDanToc)
        {
            _context.TbTrinhDoTiengDanTocs.Add(TbTrinhDoTiengDanToc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbTrinhDoTiengDanTocExists(TbTrinhDoTiengDanToc.IdTrinhDoTiengDanToc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbTrinhDoTiengDanToc", new { id = TbTrinhDoTiengDanToc.IdTrinhDoTiengDanToc }, TbTrinhDoTiengDanToc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbTrinhDoTiengDanToc(int id)
        {
            var TbTrinhDoTiengDanToc = await _context.TbTrinhDoTiengDanTocs.FindAsync(id);
            if (TbTrinhDoTiengDanToc == null)
            {
                return NotFound();
            }

            _context.TbTrinhDoTiengDanTocs.Remove(TbTrinhDoTiengDanToc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbTrinhDoTiengDanTocExists(int id)
        {
            return _context.TbTrinhDoTiengDanTocs.Any(e => e.IdTrinhDoTiengDanToc == id);
        }
    }
}
