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
    public class ChucDanhKhoaHocCuaCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public ChucDanhKhoaHocCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbChucDanhKhoaHocCuaCanBo>>> GetTbChucDanhKhoaHocCuaCanBos()
        {
            return await _context.TbChucDanhKhoaHocCuaCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbChucDanhKhoaHocCuaCanBo>> GetTbChucDanhKhoaHocCuaCanBo(int id)
        {
            var TbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos.FindAsync(id);

            if (TbChucDanhKhoaHocCuaCanBo == null)
            {
                return NotFound();
            }

            return TbChucDanhKhoaHocCuaCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbChucDanhKhoaHocCuaCanBo(int id, TbChucDanhKhoaHocCuaCanBo TbChucDanhKhoaHocCuaCanBo)
        {
            if (id != TbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHocCuaCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbChucDanhKhoaHocCuaCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbChucDanhKhoaHocCuaCanBoExists(id))
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
        public async Task<ActionResult<TbChucDanhKhoaHocCuaCanBo>> PostTbChucDanhKhoaHocCuaCanBo(TbChucDanhKhoaHocCuaCanBo TbChucDanhKhoaHocCuaCanBo)
        {
            _context.TbChucDanhKhoaHocCuaCanBos.Add(TbChucDanhKhoaHocCuaCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbChucDanhKhoaHocCuaCanBoExists(TbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHocCuaCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbChucDanhKhoaHocCuaCanBo", new { id = TbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHocCuaCanBo }, TbChucDanhKhoaHocCuaCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbChucDanhKhoaHocCuaCanBo(int id)
        {
            var TbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos.FindAsync(id);
            if (TbChucDanhKhoaHocCuaCanBo == null)
            {
                return NotFound();
            }

            _context.TbChucDanhKhoaHocCuaCanBos.Remove(TbChucDanhKhoaHocCuaCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbChucDanhKhoaHocCuaCanBoExists(int id)
        {
            return _context.TbChucDanhKhoaHocCuaCanBos.Any(e => e.IdChucDanhKhoaHocCuaCanBo == id);
        }
    }
}
