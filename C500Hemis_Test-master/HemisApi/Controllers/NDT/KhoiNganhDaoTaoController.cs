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
    public class KhoiNganhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public KhoiNganhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKhoiNganhDaoTao>>> GetTbKhoiNganhDaoTaos()
        {
            return await _context.TbKhoiNganhDaoTaos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKhoiNganhDaoTao>> GetTbKhoiNganhDaoTao(int id)
        {
            var TbKhoiNganhDaoTao = await _context.TbKhoiNganhDaoTaos.FindAsync(id);

            if (TbKhoiNganhDaoTao == null)
            {
                return NotFound();
            }

            return TbKhoiNganhDaoTao;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKhoiNganhDaoTao(int id, TbKhoiNganhDaoTao TbKhoiNganhDaoTao)
        {
            if (id != TbKhoiNganhDaoTao.IdKhoiNganhDaoTao)
            {
                return BadRequest();
            }

            _context.Entry(TbKhoiNganhDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKhoiNganhDaoTaoExists(id))
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
        public async Task<ActionResult<TbKhoiNganhDaoTao>> PostTbKhoiNganhDaoTao(TbKhoiNganhDaoTao TbKhoiNganhDaoTao)
        {
            _context.TbKhoiNganhDaoTaos.Add(TbKhoiNganhDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbKhoiNganhDaoTaoExists(TbKhoiNganhDaoTao.IdKhoiNganhDaoTao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbKhoiNganhDaoTao", new { id = TbKhoiNganhDaoTao.IdKhoiNganhDaoTao }, TbKhoiNganhDaoTao);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKhoiNganhDaoTao(int id)
        {
            var TbKhoiNganhDaoTao = await _context.TbKhoiNganhDaoTaos.FindAsync(id);
            if (TbKhoiNganhDaoTao == null)
            {
                return NotFound();
            }

            _context.TbKhoiNganhDaoTaos.Remove(TbKhoiNganhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKhoiNganhDaoTaoExists(int id)
        {
            return _context.TbKhoiNganhDaoTaos.Any(e => e.IdKhoiNganhDaoTao == id);
        }
    }
}
