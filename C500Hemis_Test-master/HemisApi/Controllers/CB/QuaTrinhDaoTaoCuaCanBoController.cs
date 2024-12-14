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
    public class QuaTrinhDaoTaoCuaCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public QuaTrinhDaoTaoCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbQuaTrinhDaoTaoCuaCanBo>>> GetTbQuaTrinhDaoTaoCuaCanBos()
        {
            return await _context.TbQuaTrinhDaoTaoCuaCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbQuaTrinhDaoTaoCuaCanBo>> GetTbQuaTrinhDaoTaoCuaCanBo(int id)
        {
            var TbQuaTrinhDaoTaoCuaCanBo = await _context.TbQuaTrinhDaoTaoCuaCanBos.FindAsync(id);

            if (TbQuaTrinhDaoTaoCuaCanBo == null)
            {
                return NotFound();
            }

            return TbQuaTrinhDaoTaoCuaCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbQuaTrinhDaoTaoCuaCanBo(int id, TbQuaTrinhDaoTaoCuaCanBo TbQuaTrinhDaoTaoCuaCanBo)
        {
            if (id != TbQuaTrinhDaoTaoCuaCanBo.IdQuaTrinhDaoTaoCuaCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbQuaTrinhDaoTaoCuaCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbQuaTrinhDaoTaoCuaCanBoExists(id))
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
        public async Task<ActionResult<TbQuaTrinhDaoTaoCuaCanBo>> PostTbQuaTrinhDaoTaoCuaCanBo(TbQuaTrinhDaoTaoCuaCanBo TbQuaTrinhDaoTaoCuaCanBo)
        {
            _context.TbQuaTrinhDaoTaoCuaCanBos.Add(TbQuaTrinhDaoTaoCuaCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbQuaTrinhDaoTaoCuaCanBoExists(TbQuaTrinhDaoTaoCuaCanBo.IdQuaTrinhDaoTaoCuaCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbQuaTrinhDaoTaoCuaCanBo", new { id = TbQuaTrinhDaoTaoCuaCanBo.IdQuaTrinhDaoTaoCuaCanBo }, TbQuaTrinhDaoTaoCuaCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbQuaTrinhDaoTaoCuaCanBo(int id)
        {
            var TbQuaTrinhDaoTaoCuaCanBo = await _context.TbQuaTrinhDaoTaoCuaCanBos.FindAsync(id);
            if (TbQuaTrinhDaoTaoCuaCanBo == null)
            {
                return NotFound();
            }

            _context.TbQuaTrinhDaoTaoCuaCanBos.Remove(TbQuaTrinhDaoTaoCuaCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbQuaTrinhDaoTaoCuaCanBoExists(int id)
        {
            return _context.TbQuaTrinhDaoTaoCuaCanBos.Any(e => e.IdQuaTrinhDaoTaoCuaCanBo == id);
        }
    }
}
