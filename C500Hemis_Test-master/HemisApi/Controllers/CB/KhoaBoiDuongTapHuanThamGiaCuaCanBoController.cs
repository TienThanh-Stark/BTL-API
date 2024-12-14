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
    public class KhoaBoiDuongTapHuanThamGiaCuaCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public KhoaBoiDuongTapHuanThamGiaCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo>>> GetTbKhoaBoiDuongTapHuanThamGiaCuaCanBos()
        {
            return await _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo>> GetTbKhoaBoiDuongTapHuanThamGiaCuaCanBo(int id)
        {
            var TbKhoaBoiDuongTapHuanThamGiaCuaCanBo = await _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.FindAsync(id);

            if (TbKhoaBoiDuongTapHuanThamGiaCuaCanBo == null)
            {
                return NotFound();
            }

            return TbKhoaBoiDuongTapHuanThamGiaCuaCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbKhoaBoiDuongTapHuanThamGiaCuaCanBo(int id, TbKhoaBoiDuongTapHuanThamGiaCuaCanBo TbKhoaBoiDuongTapHuanThamGiaCuaCanBo)
        {
            if (id != TbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbKhoaBoiDuongTapHuanThamGiaCuaCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbKhoaBoiDuongTapHuanThamGiaCuaCanBoExists(id))
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
        public async Task<ActionResult<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo>> PostTbKhoaBoiDuongTapHuanThamGiaCuaCanBo(TbKhoaBoiDuongTapHuanThamGiaCuaCanBo TbKhoaBoiDuongTapHuanThamGiaCuaCanBo)
        {
            _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.Add(TbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbKhoaBoiDuongTapHuanThamGiaCuaCanBoExists(TbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbKhoaBoiDuongTapHuanThamGiaCuaCanBo", new { id = TbKhoaBoiDuongTapHuanThamGiaCuaCanBo.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo }, TbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbKhoaBoiDuongTapHuanThamGiaCuaCanBo(int id)
        {
            var TbKhoaBoiDuongTapHuanThamGiaCuaCanBo = await _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.FindAsync(id);
            if (TbKhoaBoiDuongTapHuanThamGiaCuaCanBo == null)
            {
                return NotFound();
            }

            _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.Remove(TbKhoaBoiDuongTapHuanThamGiaCuaCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbKhoaBoiDuongTapHuanThamGiaCuaCanBoExists(int id)
        {
            return _context.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos.Any(e => e.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo == id);
        }
    }
}
