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
    public class QuaTrinhCongTacCuaCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public QuaTrinhCongTacCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbQuaTrinhCongTacCuaCanBo>>> GetTbQuaTrinhCongTacCuaCanBos()
        {
            return await _context.TbQuaTrinhCongTacCuaCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbQuaTrinhCongTacCuaCanBo>> GetTbQuaTrinhCongTacCuaCanBo(int id)
        {
            var TbQuaTrinhCongTacCuaCanBo = await _context.TbQuaTrinhCongTacCuaCanBos.FindAsync(id);

            if (TbQuaTrinhCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            return TbQuaTrinhCongTacCuaCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbQuaTrinhCongTacCuaCanBo(int id, TbQuaTrinhCongTacCuaCanBo TbQuaTrinhCongTacCuaCanBo)
        {
            if (id != TbQuaTrinhCongTacCuaCanBo.IdQuaTrinhCongTacCuaCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbQuaTrinhCongTacCuaCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbQuaTrinhCongTacCuaCanBoExists(id))
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
        public async Task<ActionResult<TbQuaTrinhCongTacCuaCanBo>> PostTbQuaTrinhCongTacCuaCanBo(TbQuaTrinhCongTacCuaCanBo TbQuaTrinhCongTacCuaCanBo)
        {
            _context.TbQuaTrinhCongTacCuaCanBos.Add(TbQuaTrinhCongTacCuaCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbQuaTrinhCongTacCuaCanBoExists(TbQuaTrinhCongTacCuaCanBo.IdQuaTrinhCongTacCuaCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbQuaTrinhCongTacCuaCanBo", new { id = TbQuaTrinhCongTacCuaCanBo.IdQuaTrinhCongTacCuaCanBo }, TbQuaTrinhCongTacCuaCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbQuaTrinhCongTacCuaCanBo(int id)
        {
            var TbQuaTrinhCongTacCuaCanBo = await _context.TbQuaTrinhCongTacCuaCanBos.FindAsync(id);
            if (TbQuaTrinhCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            _context.TbQuaTrinhCongTacCuaCanBos.Remove(TbQuaTrinhCongTacCuaCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbQuaTrinhCongTacCuaCanBoExists(int id)
        {
            return _context.TbQuaTrinhCongTacCuaCanBos.Any(e => e.IdQuaTrinhCongTacCuaCanBo == id);
        }
    }
}
