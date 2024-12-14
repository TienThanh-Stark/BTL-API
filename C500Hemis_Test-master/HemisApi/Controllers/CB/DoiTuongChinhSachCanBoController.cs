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
    public class DoiTuongChinhSachCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public DoiTuongChinhSachCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDoiTuongChinhSachCanBo>>> GetTbDoiTuongChinhSachCanBos()
        {
            return await _context.TbDoiTuongChinhSachCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDoiTuongChinhSachCanBo>> GetTbDoiTuongChinhSachCanBo(int id)
        {
            var TbDoiTuongChinhSachCanBo = await _context.TbDoiTuongChinhSachCanBos.FindAsync(id);

            if (TbDoiTuongChinhSachCanBo == null)
            {
                return NotFound();
            }

            return TbDoiTuongChinhSachCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDoiTuongChinhSachCanBo(int id, TbDoiTuongChinhSachCanBo TbDoiTuongChinhSachCanBo)
        {
            if (id != TbDoiTuongChinhSachCanBo.IdDoiTuongChinhSachCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbDoiTuongChinhSachCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDoiTuongChinhSachCanBoExists(id))
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
        public async Task<ActionResult<TbDoiTuongChinhSachCanBo>> PostTbDoiTuongChinhSachCanBo(TbDoiTuongChinhSachCanBo TbDoiTuongChinhSachCanBo)
        {
            _context.TbDoiTuongChinhSachCanBos.Add(TbDoiTuongChinhSachCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDoiTuongChinhSachCanBoExists(TbDoiTuongChinhSachCanBo.IdDoiTuongChinhSachCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDoiTuongChinhSachCanBo", new { id = TbDoiTuongChinhSachCanBo.IdDoiTuongChinhSachCanBo }, TbDoiTuongChinhSachCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDoiTuongChinhSachCanBo(int id)
        {
            var TbDoiTuongChinhSachCanBo = await _context.TbDoiTuongChinhSachCanBos.FindAsync(id);
            if (TbDoiTuongChinhSachCanBo == null)
            {
                return NotFound();
            }

            _context.TbDoiTuongChinhSachCanBos.Remove(TbDoiTuongChinhSachCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDoiTuongChinhSachCanBoExists(int id)
        {
            return _context.TbDoiTuongChinhSachCanBos.Any(e => e.IdDoiTuongChinhSachCanBo == id);
        }
    }
}
