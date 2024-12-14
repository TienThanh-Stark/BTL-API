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
    public class DonViCongTacCuaCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public DonViCongTacCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDonViCongTacCuaCanBo>>> GetTbDonViCongTacCuaCanBos()
        {
            return await _context.TbDonViCongTacCuaCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDonViCongTacCuaCanBo>> GetTbDonViCongTacCuaCanBo(int id)
        {
            var TbDonViCongTacCuaCanBo = await _context.TbDonViCongTacCuaCanBos.FindAsync(id);

            if (TbDonViCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            return TbDonViCongTacCuaCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDonViCongTacCuaCanBo(int id, TbDonViCongTacCuaCanBo TbDonViCongTacCuaCanBo)
        {
            if (id != TbDonViCongTacCuaCanBo.IdDvct)
            {
                return BadRequest();
            }

            _context.Entry(TbDonViCongTacCuaCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDonViCongTacCuaCanBoExists(id))
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
        public async Task<ActionResult<TbDonViCongTacCuaCanBo>> PostTbDonViCongTacCuaCanBo(TbDonViCongTacCuaCanBo TbDonViCongTacCuaCanBo)
        {
            _context.TbDonViCongTacCuaCanBos.Add(TbDonViCongTacCuaCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDonViCongTacCuaCanBoExists(TbDonViCongTacCuaCanBo.IdDvct))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDonViCongTacCuaCanBo", new { id = TbDonViCongTacCuaCanBo.IdDvct }, TbDonViCongTacCuaCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDonViCongTacCuaCanBo(int id)
        {
            var TbDonViCongTacCuaCanBo = await _context.TbDonViCongTacCuaCanBos.FindAsync(id);
            if (TbDonViCongTacCuaCanBo == null)
            {
                return NotFound();
            }

            _context.TbDonViCongTacCuaCanBos.Remove(TbDonViCongTacCuaCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDonViCongTacCuaCanBoExists(int id)
        {
            return _context.TbDonViCongTacCuaCanBos.Any(e => e.IdDvct == id);
        }
    }
}
