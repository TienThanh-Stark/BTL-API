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
    public class KyLuatCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public KyLuatCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKyLuatCanBo>>> GetTbKyLuatCanBos()
        {
            return await _context.TbKyLuatCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKyLuatCanBo>> GetTbKyLuatCanBo(int id)
        {
            var TbKyLuatCanBo = await _context.TbKyLuatCanBos.FindAsync(id);

            if (TbKyLuatCanBo == null)
            {
                return NotFound();
            }

            return TbKyLuatCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKyLuatCanBo(int id, TbKyLuatCanBo TbKyLuatCanBo)
        {
            if (id != TbKyLuatCanBo.IdKyLuatCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbKyLuatCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKyLuatCanBoExists(id))
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
        public async Task<ActionResult<TbKyLuatCanBo>> PostTbKyLuatCanBo(TbKyLuatCanBo TbKyLuatCanBo)
        {
            _context.TbKyLuatCanBos.Add(TbKyLuatCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbKyLuatCanBoExists(TbKyLuatCanBo.IdKyLuatCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbKyLuatCanBo", new { id = TbKyLuatCanBo.IdKyLuatCanBo }, TbKyLuatCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKyLuatCanBo(int id)
        {
            var TbKyLuatCanBo = await _context.TbKyLuatCanBos.FindAsync(id);
            if (TbKyLuatCanBo == null)
            {
                return NotFound();
            }

            _context.TbKyLuatCanBos.Remove(TbKyLuatCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKyLuatCanBoExists(int id)
        {
            return _context.TbKyLuatCanBos.Any(e => e.IdKyLuatCanBo == id);
        }
    }
}
