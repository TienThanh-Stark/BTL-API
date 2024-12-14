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
    public class NganhGiangDayCuaCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public NganhGiangDayCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbNganhGiangDayCuaCanBo>>> GetTbNganhGiangDayCuaCanBos()
        {
            return await _context.TbNganhGiangDayCuaCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbNganhGiangDayCuaCanBo>> GetTbNganhGiangDayCuaCanBo(int id)
        {
            var TbNganhGiangDayCuaCanBo = await _context.TbNganhGiangDayCuaCanBos.FindAsync(id);

            if (TbNganhGiangDayCuaCanBo == null)
            {
                return NotFound();
            }

            return TbNganhGiangDayCuaCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbNganhGiangDayCuaCanBo(int id, TbNganhGiangDayCuaCanBo TbNganhGiangDayCuaCanBo)
        {
            if (id != TbNganhGiangDayCuaCanBo.IdNganhGiangDayCuaCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbNganhGiangDayCuaCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNganhGiangDayCuaCanBoExists(id))
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
        public async Task<ActionResult<TbNganhGiangDayCuaCanBo>> PostTbNganhGiangDayCuaCanBo(TbNganhGiangDayCuaCanBo TbNganhGiangDayCuaCanBo)
        {
            _context.TbNganhGiangDayCuaCanBos.Add(TbNganhGiangDayCuaCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbNganhGiangDayCuaCanBoExists(TbNganhGiangDayCuaCanBo.IdNganhGiangDayCuaCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbNganhGiangDayCuaCanBo", new { id = TbNganhGiangDayCuaCanBo.IdNganhGiangDayCuaCanBo }, TbNganhGiangDayCuaCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbNganhGiangDayCuaCanBo(int id)
        {
            var TbNganhGiangDayCuaCanBo = await _context.TbNganhGiangDayCuaCanBos.FindAsync(id);
            if (TbNganhGiangDayCuaCanBo == null)
            {
                return NotFound();
            }

            _context.TbNganhGiangDayCuaCanBos.Remove(TbNganhGiangDayCuaCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbNganhGiangDayCuaCanBoExists(int id)
        {
            return _context.TbNganhGiangDayCuaCanBos.Any(e => e.IdNganhGiangDayCuaCanBo == id);
        }
    }
}
