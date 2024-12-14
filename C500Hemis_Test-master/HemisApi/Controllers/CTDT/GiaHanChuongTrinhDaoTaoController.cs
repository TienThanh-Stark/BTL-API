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
    public class GiaHanChuongTrinhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public GiaHanChuongTrinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGiaHanChuongTrinhDaoTao>>> GetTbGiaHanChuongTrinhDaoTaos()
        {
            return await _context.TbGiaHanChuongTrinhDaoTaos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGiaHanChuongTrinhDaoTao>> GetTbGiaHanChuongTrinhDaoTao(int id)
        {
            var TbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos.FindAsync(id);

            if (TbGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return TbGiaHanChuongTrinhDaoTao;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGiaHanChuongTrinhDaoTao(int id, TbGiaHanChuongTrinhDaoTao TbGiaHanChuongTrinhDaoTao)
        {
            if (id != TbGiaHanChuongTrinhDaoTao.IdGiaHanChuongTrinhDaoTao)
            {
                return BadRequest();
            }

            _context.Entry(TbGiaHanChuongTrinhDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGiaHanChuongTrinhDaoTaoExists(id))
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
        public async Task<ActionResult<TbGiaHanChuongTrinhDaoTao>> PostTbGiaHanChuongTrinhDaoTao(TbGiaHanChuongTrinhDaoTao TbGiaHanChuongTrinhDaoTao)
        {
            _context.TbGiaHanChuongTrinhDaoTaos.Add(TbGiaHanChuongTrinhDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbGiaHanChuongTrinhDaoTaoExists(TbGiaHanChuongTrinhDaoTao.IdGiaHanChuongTrinhDaoTao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbGiaHanChuongTrinhDaoTao", new { id = TbGiaHanChuongTrinhDaoTao.IdGiaHanChuongTrinhDaoTao }, TbGiaHanChuongTrinhDaoTao);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGiaHanChuongTrinhDaoTao(int id)
        {
            var TbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos.FindAsync(id);
            if (TbGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            _context.TbGiaHanChuongTrinhDaoTaos.Remove(TbGiaHanChuongTrinhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGiaHanChuongTrinhDaoTaoExists(int id)
        {
            return _context.TbGiaHanChuongTrinhDaoTaos.Any(e => e.IdGiaHanChuongTrinhDaoTao == id);
        }
    }
}
