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
    public class DonViThinhGiangCuaCanBoController : ControllerBase
    {
        private readonly HemisContext _context;

        public DonViThinhGiangCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDonViThinhGiangCuaCanBo>>> GetTbDonViThinhGiangCuaCanBos()
        {
            return await _context.TbDonViThinhGiangCuaCanBos.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDonViThinhGiangCuaCanBo>> GetTbDonViThinhGiangCuaCanBo(int id)
        {
            var TbDonViThinhGiangCuaCanBo = await _context.TbDonViThinhGiangCuaCanBos.FindAsync(id);

            if (TbDonViThinhGiangCuaCanBo == null)
            {
                return NotFound();
            }

            return TbDonViThinhGiangCuaCanBo;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDonViThinhGiangCuaCanBo(int id, TbDonViThinhGiangCuaCanBo TbDonViThinhGiangCuaCanBo)
        {
            if (id != TbDonViThinhGiangCuaCanBo.IdDonViThinhGiangCuaCanBo)
            {
                return BadRequest();
            }

            _context.Entry(TbDonViThinhGiangCuaCanBo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDonViThinhGiangCuaCanBoExists(id))
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
        public async Task<ActionResult<TbDonViThinhGiangCuaCanBo>> PostTbDonViThinhGiangCuaCanBo(TbDonViThinhGiangCuaCanBo TbDonViThinhGiangCuaCanBo)
        {
            _context.TbDonViThinhGiangCuaCanBos.Add(TbDonViThinhGiangCuaCanBo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDonViThinhGiangCuaCanBoExists(TbDonViThinhGiangCuaCanBo.IdDonViThinhGiangCuaCanBo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDonViThinhGiangCuaCanBo", new { id = TbDonViThinhGiangCuaCanBo.IdDonViThinhGiangCuaCanBo }, TbDonViThinhGiangCuaCanBo);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDonViThinhGiangCuaCanBo(int id)
        {
            var TbDonViThinhGiangCuaCanBo = await _context.TbDonViThinhGiangCuaCanBos.FindAsync(id);
            if (TbDonViThinhGiangCuaCanBo == null)
            {
                return NotFound();
            }

            _context.TbDonViThinhGiangCuaCanBos.Remove(TbDonViThinhGiangCuaCanBo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDonViThinhGiangCuaCanBoExists(int id)
        {
            return _context.TbDonViThinhGiangCuaCanBos.Any(e => e.IdDonViThinhGiangCuaCanBo == id);
        }
    }
}
