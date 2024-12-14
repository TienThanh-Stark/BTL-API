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
    public class CanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public CanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCanBo>>> GetTbCanBos()
        {
            return await _context.TbCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCanBo>> GetTbCanBo(int id)
        {
            var tbCanBo = await _context.TbCanBos.FindAsync(id);

            if (tbCanBo == null)
            {
                return NotFound();
            }

            return tbCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCanBo(int id, TbCanBo tbCanBo)
        {
            if (id != tbCanBo.IdCanBo)
            {
                return BadRequest();
            }

            _context.Entry(tbCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCanBoExists(id))
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
        public async Task<ActionResult<TbCanBo>> PostTbCanBo(TbCanBo tbCanBo)
        {
            _context.TbCanBos.Add(tbCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbCanBoExists(tbCanBo.IdCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbCanBo", new { id = tbCanBo.IdCanBo }, tbCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCanBo(int id)
        {
            var tbCanBo = await _context.TbCanBos.FindAsync(id);
            if (tbCanBo == null)
            {
                return NotFound();
            }

            _context.TbCanBos.Remove(tbCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCanBoExists(int id)
        {
            return _context.TbCanBos.Any(e => e.IdCanBo == id);
        }
    }
}
