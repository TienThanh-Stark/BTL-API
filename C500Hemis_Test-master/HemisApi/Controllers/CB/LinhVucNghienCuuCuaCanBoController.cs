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
    public class LinhVucNghienCuuCuaCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public LinhVucNghienCuuCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbLinhVucNghienCuuCuaCanBo>>> GetTbLinhVucNghienCuuCuaCanBos()
        {
            return await _context.TbLinhVucNghienCuuCuaCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbLinhVucNghienCuuCuaCanBo>> GetTbLinhVucNghienCuuCuaCanBo(int id)
        {
            var TbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos.FindAsync(id);

            if (TbLinhVucNghienCuuCuaCanBo == null)
            {
                return NotFound();
            }

            return TbLinhVucNghienCuuCuaCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbLinhVucNghienCuuCuaCanBo(int id, TbLinhVucNghienCuuCuaCanBo TbLinhVucNghienCuuCuaCanBo)
        {
            if (id != TbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuuCuaCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbLinhVucNghienCuuCuaCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbLinhVucNghienCuuCuaCanBoExists(id))
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
        public async Task<ActionResult<TbLinhVucNghienCuuCuaCanBo>> PostTbLinhVucNghienCuuCuaCanBo(TbLinhVucNghienCuuCuaCanBo TbLinhVucNghienCuuCuaCanBo)
        {
            _context.TbLinhVucNghienCuuCuaCanBos.Add(TbLinhVucNghienCuuCuaCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbLinhVucNghienCuuCuaCanBoExists(TbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuuCuaCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbLinhVucNghienCuuCuaCanBo", new { id = TbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuuCuaCanBo }, TbLinhVucNghienCuuCuaCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbLinhVucNghienCuuCuaCanBo(int id)
        {
            var TbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos.FindAsync(id);
            if (TbLinhVucNghienCuuCuaCanBo == null)
            {
                return NotFound();
            }

            _context.TbLinhVucNghienCuuCuaCanBos.Remove(TbLinhVucNghienCuuCuaCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbLinhVucNghienCuuCuaCanBoExists(int id)
        {
            return _context.TbLinhVucNghienCuuCuaCanBos.Any(e => e.IdLinhVucNghienCuuCuaCanBo == id);
        }
    }
}
