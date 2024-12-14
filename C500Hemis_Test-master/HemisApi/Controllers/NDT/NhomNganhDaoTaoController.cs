using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.NDT
{
    [Route("api/ndt/[controller]")]
    [ApiController]
    public class NhomNganhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public NhomNganhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNhomNganhDaoTao>>> GetTbNhomNganhDaoTaos()
        {
            return await _context.TbNhomNganhDaoTaos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNhomNganhDaoTao>> GetTbNhomNganhDaoTao(int id)
        {
            var TbNhomNganhDaoTao = await _context.TbNhomNganhDaoTaos.FindAsync(id);

            if (TbNhomNganhDaoTao == null)
            {
                return NotFound();
            }

            return TbNhomNganhDaoTao;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNhomNganhDaoTao(int id, TbNhomNganhDaoTao TbNhomNganhDaoTao)
        {
            if (id != TbNhomNganhDaoTao.IdNhomNganhDaoTao)
            {
                return BadRequest();
            }

            _context.Entry(TbNhomNganhDaoTao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNhomNganhDaoTaoExists(id))
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
        public async Task<ActionResult<TbNhomNganhDaoTao>> PostTbNhomNganhDaoTao(TbNhomNganhDaoTao TbNhomNganhDaoTao)
        {
            _context.TbNhomNganhDaoTaos.Add(TbNhomNganhDaoTao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNhomNganhDaoTaoExists(TbNhomNganhDaoTao.IdNhomNganhDaoTao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNhomNganhDaoTao", new { id = TbNhomNganhDaoTao.IdNhomNganhDaoTao }, TbNhomNganhDaoTao);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNhomNganhDaoTao(int id)
        {
            var TbNhomNganhDaoTao = await _context.TbNhomNganhDaoTaos.FindAsync(id);
            if (TbNhomNganhDaoTao == null)
            {
                return NotFound();
            }

            _context.TbNhomNganhDaoTaos.Remove(TbNhomNganhDaoTao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNhomNganhDaoTaoExists(int id)
        {
            return _context.TbNhomNganhDaoTaos.Any(e => e.IdNhomNganhDaoTao == id);
        }
    }
}
