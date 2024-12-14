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
    public class ThongTinLinhVucDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinLinhVucDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinLinhVucDaoTao>>> GetTbThongTinLinhVucDaoTaos()
        {
            return await _context.TbThongTinLinhVucDaoTaos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinLinhVucDaoTao>> GetTbThongTinLinhVucDaoTao(int id)
        {
            var TbThongTinLinhVucDaoTao = await _context.TbThongTinLinhVucDaoTaos.FindAsync(id);

            if (TbThongTinLinhVucDaoTao == null)
            {
                return NotFound();
            }

            return TbThongTinLinhVucDaoTao;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinLinhVucDaoTao(int id, TbThongTinLinhVucDaoTao TbThongTinLinhVucDaoTao)
        {
            if (id != TbThongTinLinhVucDaoTao.IdThongTinLinhVucDaoTao)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinLinhVucDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinLinhVucDaoTaoExists(id))
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
        public async Task<ActionResult<TbThongTinLinhVucDaoTao>> PostTbThongTinLinhVucDaoTao(TbThongTinLinhVucDaoTao TbThongTinLinhVucDaoTao)
        {
            _context.TbThongTinLinhVucDaoTaos.Add(TbThongTinLinhVucDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinLinhVucDaoTaoExists(TbThongTinLinhVucDaoTao.IdThongTinLinhVucDaoTao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinLinhVucDaoTao", new { id = TbThongTinLinhVucDaoTao.IdThongTinLinhVucDaoTao }, TbThongTinLinhVucDaoTao);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinLinhVucDaoTao(int id)
        {
            var TbThongTinLinhVucDaoTao = await _context.TbThongTinLinhVucDaoTaos.FindAsync(id);
            if (TbThongTinLinhVucDaoTao == null)
            {
                return NotFound();
            }

            _context.TbThongTinLinhVucDaoTaos.Remove(TbThongTinLinhVucDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinLinhVucDaoTaoExists(int id)
        {
            return _context.TbThongTinLinhVucDaoTaos.Any(e => e.IdThongTinLinhVucDaoTao == id);
        }
    }
}
