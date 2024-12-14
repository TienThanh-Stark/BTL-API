using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.KHCN
{
    [Route("api/khcn/[controller]")]
    [ApiController]
    public class BaiBaoKHDaCongBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public BaiBaoKHDaCongBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbBaiBaoKhdaCongBo>>> GetTbBaiBaoKhdaCongBos()
        {
            return await _context.TbBaiBaoKhdaCongBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbBaiBaoKhdaCongBo>> GetTbBaiBaoKhdaCongBo(int id)
        {
            var TbBaiBaoKhdaCongBo = await _context.TbBaiBaoKhdaCongBos.FindAsync(id);

            if (TbBaiBaoKhdaCongBo == null)
            {
                return NotFound();
            }

            return TbBaiBaoKhdaCongBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbBaiBaoKhdaCongBo(int id, TbBaiBaoKhdaCongBo TbBaiBaoKhdaCongBo)
        {
            if (id != TbBaiBaoKhdaCongBo.IdBaiBaoKhdaCongBo)
            {
                return BadRequest();
            }

            _context.Entry(TbBaiBaoKhdaCongBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBaiBaoKhdaCongBoExists(id))
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
        public async Task<ActionResult<TbBaiBaoKhdaCongBo>> PostTbBaiBaoKhdaCongBo(TbBaiBaoKhdaCongBo TbBaiBaoKhdaCongBo)
        {
            _context.TbBaiBaoKhdaCongBos.Add(TbBaiBaoKhdaCongBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbBaiBaoKhdaCongBoExists(TbBaiBaoKhdaCongBo.IdBaiBaoKhdaCongBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbBaiBaoKhdaCongBo", new { id = TbBaiBaoKhdaCongBo.IdBaiBaoKhdaCongBo }, TbBaiBaoKhdaCongBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbBaiBaoKhdaCongBo(int id)
        {
            var TbBaiBaoKhdaCongBo = await _context.TbBaiBaoKhdaCongBos.FindAsync(id);
            if (TbBaiBaoKhdaCongBo == null)
            {
                return NotFound();
            }

            _context.TbBaiBaoKhdaCongBos.Remove(TbBaiBaoKhdaCongBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbBaiBaoKhdaCongBoExists(int id)
        {
            return _context.TbBaiBaoKhdaCongBos.Any(e => e.IdBaiBaoKhdaCongBo == id);
        }
    }
}
