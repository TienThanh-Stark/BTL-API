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
    public class DanhSachNganhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanhSachNganhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDanhSachNganhDaoTao>>> GetTbDanhSachNganhDaoTaos()
        {
            return await _context.TbDanhSachNganhDaoTaos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDanhSachNganhDaoTao>> GetTbDanhSachNganhDaoTao(int id)
        {
            var TbDanhSachNganhDaoTao = await _context.TbDanhSachNganhDaoTaos.FindAsync(id);

            if (TbDanhSachNganhDaoTao == null)
            {
                return NotFound();
            }

            return TbDanhSachNganhDaoTao;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDanhSachNganhDaoTao(int id, TbDanhSachNganhDaoTao TbDanhSachNganhDaoTao)
        {
            if (id != TbDanhSachNganhDaoTao.IdDanhSachNganhDaoTao)
            {
                return BadRequest();
            }

            _context.Entry(TbDanhSachNganhDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDanhSachNganhDaoTaoExists(id))
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
        public async Task<ActionResult<TbDanhSachNganhDaoTao>> PostTbDanhSachNganhDaoTao(TbDanhSachNganhDaoTao TbDanhSachNganhDaoTao)
        {
            _context.TbDanhSachNganhDaoTaos.Add(TbDanhSachNganhDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDanhSachNganhDaoTaoExists(TbDanhSachNganhDaoTao.IdDanhSachNganhDaoTao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDanhSachNganhDaoTao", new { id = TbDanhSachNganhDaoTao.IdDanhSachNganhDaoTao }, TbDanhSachNganhDaoTao);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDanhSachNganhDaoTao(int id)
        {
            var TbDanhSachNganhDaoTao = await _context.TbDanhSachNganhDaoTaos.FindAsync(id);
            if (TbDanhSachNganhDaoTao == null)
            {
                return NotFound();
            }

            _context.TbDanhSachNganhDaoTaos.Remove(TbDanhSachNganhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDanhSachNganhDaoTaoExists(int id)
        {
            return _context.TbDanhSachNganhDaoTaos.Any(e => e.IdDanhSachNganhDaoTao == id);
        }
    }
}
