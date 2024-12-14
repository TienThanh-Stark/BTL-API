using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSVC
{
    [Route("api/csvc/[controller]")]
    [ApiController]
    public class DatDaiController : ControllerBase
    {
        private readonly HemisContext _context;

        public DatDaiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDatDai>>> GetTbDatDais()
        {
            return await _context.TbDatDais.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDatDai>> GetTbDatDai(int id)
        {
            var TbDatDai = await _context.TbDatDais.FindAsync(id);

            if (TbDatDai == null)
            {
                return NotFound();
            }

            return TbDatDai;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDatDai(int id, TbDatDai TbDatDai)
        {
            if (id != TbDatDai.IdDatDai)
            {
                return BadRequest();
            }

            _context.Entry(TbDatDai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDatDaiExists(id))
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
        public async Task<ActionResult<TbDatDai>> PostTbDatDai(TbDatDai TbDatDai)
        {
            _context.TbDatDais.Add(TbDatDai);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbDatDaiExists(TbDatDai.IdDatDai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbDatDai", new { id = TbDatDai.IdDatDai }, TbDatDai);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDatDai(int id)
        {
            var TbDatDai = await _context.TbDatDais.FindAsync(id);
            if (TbDatDai == null)
            {
                return NotFound();
            }

            _context.TbDatDais.Remove(TbDatDai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDatDaiExists(int id)
        {
            return _context.TbDatDais.Any(e => e.IdDatDai == id);
        }
    }
}
