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
    public class DanhGiaXepLoaiCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public DanhGiaXepLoaiCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDanhGiaXepLoaiCanBo>>> GetTbDanhGiaXepLoaiCanBos()
        {
            return await _context.TbDanhGiaXepLoaiCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDanhGiaXepLoaiCanBo>> GetTbDanhGiaXepLoaiCanBo(int id)
        {
            var TbDanhGiaXepLoaiCanBo = await _context.TbDanhGiaXepLoaiCanBos.FindAsync(id);

            if (TbDanhGiaXepLoaiCanBo == null)
            {
                return NotFound();
            }

            return TbDanhGiaXepLoaiCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDanhGiaXepLoaiCanBo(int id, TbDanhGiaXepLoaiCanBo TbDanhGiaXepLoaiCanBo)
        {
            if (id != TbDanhGiaXepLoaiCanBo.IdDanhGiaXepLoaiCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbDanhGiaXepLoaiCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDanhGiaXepLoaiCanBoExists(id))
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
        public async Task<ActionResult<TbDanhGiaXepLoaiCanBo>> PostTbDanhGiaXepLoaiCanBo(TbDanhGiaXepLoaiCanBo TbDanhGiaXepLoaiCanBo)
        {
            _context.TbDanhGiaXepLoaiCanBos.Add(TbDanhGiaXepLoaiCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDanhGiaXepLoaiCanBoExists(TbDanhGiaXepLoaiCanBo.IdDanhGiaXepLoaiCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDanhGiaXepLoaiCanBo", new { id = TbDanhGiaXepLoaiCanBo.IdDanhGiaXepLoaiCanBo }, TbDanhGiaXepLoaiCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDanhGiaXepLoaiCanBo(int id)
        {
            var TbDanhGiaXepLoaiCanBo = await _context.TbDanhGiaXepLoaiCanBos.FindAsync(id);
            if (TbDanhGiaXepLoaiCanBo == null)
            {
                return NotFound();
            }

            _context.TbDanhGiaXepLoaiCanBos.Remove(TbDanhGiaXepLoaiCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDanhGiaXepLoaiCanBoExists(int id)
        {
            return _context.TbDanhGiaXepLoaiCanBos.Any(e => e.IdDanhGiaXepLoaiCanBo == id);
        }
    }
}
