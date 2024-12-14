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
    public class ChuongTrinhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChuongTrinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbChuongTrinhDaoTao>>> GetTbChuongTrinhDaoTaos()
        {
            return await _context.TbChuongTrinhDaoTaos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbChuongTrinhDaoTao>> GetTbChuongTrinhDaoTao(int id)
        {
            var TbChuongTrinhDaoTao = await _context.TbChuongTrinhDaoTaos.FindAsync(id);

            if (TbChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return TbChuongTrinhDaoTao;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbChuongTrinhDaoTao(int id, TbChuongTrinhDaoTao TbChuongTrinhDaoTao)
        {
            if (id != TbChuongTrinhDaoTao.IdChuongTrinhDaoTao)
            {
                return BadRequest();
            }

            _context.Entry(TbChuongTrinhDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbChuongTrinhDaoTaoExists(id))
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
        public async Task<ActionResult<TbChuongTrinhDaoTao>> PostTbChuongTrinhDaoTao(TbChuongTrinhDaoTao TbChuongTrinhDaoTao)
        {
            _context.TbChuongTrinhDaoTaos.Add(TbChuongTrinhDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbChuongTrinhDaoTaoExists(TbChuongTrinhDaoTao.IdChuongTrinhDaoTao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbChuongTrinhDaoTao", new { id = TbChuongTrinhDaoTao.IdChuongTrinhDaoTao }, TbChuongTrinhDaoTao);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbChuongTrinhDaoTao(int id)
        {
            var TbChuongTrinhDaoTao = await _context.TbChuongTrinhDaoTaos.FindAsync(id);
            if (TbChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            _context.TbChuongTrinhDaoTaos.Remove(TbChuongTrinhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbChuongTrinhDaoTaoExists(int id)
        {
            return _context.TbChuongTrinhDaoTaos.Any(e => e.IdChuongTrinhDaoTao == id);
        }
    }
}
