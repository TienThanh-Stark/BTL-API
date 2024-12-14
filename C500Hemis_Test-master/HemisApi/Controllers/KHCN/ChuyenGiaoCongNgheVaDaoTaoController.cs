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
    public class ChuyenGiaoCongNgheVaDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChuyenGiaoCongNgheVaDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbChuyenGiaoCongNgheVaDaoTao>>> GetTbChuyenGiaoCongNgheVaDaoTaos()
        {
            return await _context.TbChuyenGiaoCongNgheVaDaoTaos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbChuyenGiaoCongNgheVaDaoTao>> GetTbChuyenGiaoCongNgheVaDaoTao(int id)
        {
            var TbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos.FindAsync(id);

            if (TbChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }

            return TbChuyenGiaoCongNgheVaDaoTao;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbChuyenGiaoCongNgheVaDaoTao(int id, TbChuyenGiaoCongNgheVaDaoTao TbChuyenGiaoCongNgheVaDaoTao)
        {
            if (id != TbChuyenGiaoCongNgheVaDaoTao.IdChuyenGiaoCongNgheVaDaoTao)
            {
                return BadRequest();
            }

            _context.Entry(TbChuyenGiaoCongNgheVaDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbChuyenGiaoCongNgheVaDaoTaoExists(id))
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
        public async Task<ActionResult<TbChuyenGiaoCongNgheVaDaoTao>> PostTbChuyenGiaoCongNgheVaDaoTao(TbChuyenGiaoCongNgheVaDaoTao TbChuyenGiaoCongNgheVaDaoTao)
        {
            _context.TbChuyenGiaoCongNgheVaDaoTaos.Add(TbChuyenGiaoCongNgheVaDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbChuyenGiaoCongNgheVaDaoTaoExists(TbChuyenGiaoCongNgheVaDaoTao.IdChuyenGiaoCongNgheVaDaoTao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbChuyenGiaoCongNgheVaDaoTao", new { id = TbChuyenGiaoCongNgheVaDaoTao.IdChuyenGiaoCongNgheVaDaoTao }, TbChuyenGiaoCongNgheVaDaoTao);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbChuyenGiaoCongNgheVaDaoTao(int id)
        {
            var TbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos.FindAsync(id);
            if (TbChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }

            _context.TbChuyenGiaoCongNgheVaDaoTaos.Remove(TbChuyenGiaoCongNgheVaDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbChuyenGiaoCongNgheVaDaoTaoExists(int id)
        {
            return _context.TbChuyenGiaoCongNgheVaDaoTaos.Any(e => e.IdChuyenGiaoCongNgheVaDaoTao == id);
        }
    }
}
