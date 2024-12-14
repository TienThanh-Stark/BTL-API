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
    public class ThongTinHopTacController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThongTinHopTacController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThongTinHopTac>>> GetTbThongTinHopTacs()
        {
            return await _context.TbThongTinHopTacs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThongTinHopTac>> GetTbThongTinHopTac(int id)
        {
            var TbThongTinHopTac = await _context.TbThongTinHopTacs.FindAsync(id);

            if (TbThongTinHopTac == null)
            {
                return NotFound();
            }

            return TbThongTinHopTac;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThongTinHopTac(int id, TbThongTinHopTac TbThongTinHopTac)
        {
            if (id != TbThongTinHopTac.IdThongTinHopTac)
            {
                return BadRequest();
            }

            _context.Entry(TbThongTinHopTac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThongTinHopTacExists(id))
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
        public async Task<ActionResult<TbThongTinHopTac>> PostTbThongTinHopTac(TbThongTinHopTac TbThongTinHopTac)
        {
            _context.TbThongTinHopTacs.Add(TbThongTinHopTac);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThongTinHopTacExists(TbThongTinHopTac.IdThongTinHopTac))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThongTinHopTac", new { id = TbThongTinHopTac.IdThongTinHopTac }, TbThongTinHopTac);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThongTinHopTac(int id)
        {
            var TbThongTinHopTac = await _context.TbThongTinHopTacs.FindAsync(id);
            if (TbThongTinHopTac == null)
            {
                return NotFound();
            }

            _context.TbThongTinHopTacs.Remove(TbThongTinHopTac);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThongTinHopTacExists(int id)
        {
            return _context.TbThongTinHopTacs.Any(e => e.IdThongTinHopTac == id);
        }
    }
}
