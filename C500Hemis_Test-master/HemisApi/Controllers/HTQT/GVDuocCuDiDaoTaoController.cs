using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.HTQT
{
    [Route("api/htqt/[controller]")]
    [ApiController]
    public class GVDuocCuDiDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public GVDuocCuDiDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGvduocCuDiDaoTao>>> GetTbGvduocCuDiDaoTaos()
        {
            return await _context.TbGvduocCuDiDaoTaos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGvduocCuDiDaoTao>> GetTbGvduocCuDiDaoTao(int id)
        {
            var TbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos.FindAsync(id);

            if (TbGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }

            return TbGvduocCuDiDaoTao;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGvduocCuDiDaoTao(int id, TbGvduocCuDiDaoTao TbGvduocCuDiDaoTao)
        {
            if (id != TbGvduocCuDiDaoTao.IdGvduocCuDiDaoTao)
            {
                return BadRequest();
            }

            _context.Entry(TbGvduocCuDiDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGvduocCuDiDaoTaoExists(id))
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
        public async Task<ActionResult<TbGvduocCuDiDaoTao>> PostTbGvduocCuDiDaoTao(TbGvduocCuDiDaoTao TbGvduocCuDiDaoTao)
        {
            _context.TbGvduocCuDiDaoTaos.Add(TbGvduocCuDiDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbGvduocCuDiDaoTaoExists(TbGvduocCuDiDaoTao.IdGvduocCuDiDaoTao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbGvduocCuDiDaoTao", new { id = TbGvduocCuDiDaoTao.IdGvduocCuDiDaoTao }, TbGvduocCuDiDaoTao);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGvduocCuDiDaoTao(int id)
        {
            var TbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos.FindAsync(id);
            if (TbGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }

            _context.TbGvduocCuDiDaoTaos.Remove(TbGvduocCuDiDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGvduocCuDiDaoTaoExists(int id)
        {
            return _context.TbGvduocCuDiDaoTaos.Any(e => e.IdGvduocCuDiDaoTao == id);
        }
    }
}
