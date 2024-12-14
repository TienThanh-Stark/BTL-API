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
    public class ThietBiPTN_THTren500TrController : ControllerBase
    {
        private readonly HemisContext _context;

        public ThietBiPTN_THTren500TrController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbThietBiPtnThtren500Tr>>> GetTbThietBiPtnThtren500Trs()
        {
            return await _context.TbThietBiPtnThtren500Trs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbThietBiPtnThtren500Tr>> GetTbThietBiPtnThtren500Tr(int id)
        {
            var TbThietBiPtnThtren500Tr = await _context.TbThietBiPtnThtren500Trs.FindAsync(id);

            if (TbThietBiPtnThtren500Tr == null)
            {
                return NotFound();
            }

            return TbThietBiPtnThtren500Tr;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbThietBiPtnThtren500Tr(int id, TbThietBiPtnThtren500Tr TbThietBiPtnThtren500Tr)
        {
            if (id != TbThietBiPtnThtren500Tr.IdThietBiPtnTh)
            {
                return BadRequest();
            }

            _context.Entry(TbThietBiPtnThtren500Tr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbThietBiPtnThtren500TrExists(id))
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
        public async Task<ActionResult<TbThietBiPtnThtren500Tr>> PostTbThietBiPtnThtren500Tr(TbThietBiPtnThtren500Tr TbThietBiPtnThtren500Tr)
        {
            _context.TbThietBiPtnThtren500Trs.Add(TbThietBiPtnThtren500Tr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbThietBiPtnThtren500TrExists(TbThietBiPtnThtren500Tr.IdThietBiPtnTh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbThietBiPtnThtren500Tr", new { id = TbThietBiPtnThtren500Tr.IdThietBiPtnTh }, TbThietBiPtnThtren500Tr);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbThietBiPtnThtren500Tr(int id)
        {
            var TbThietBiPtnThtren500Tr = await _context.TbThietBiPtnThtren500Trs.FindAsync(id);
            if (TbThietBiPtnThtren500Tr == null)
            {
                return NotFound();
            }

            _context.TbThietBiPtnThtren500Trs.Remove(TbThietBiPtnThtren500Tr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbThietBiPtnThtren500TrExists(int id)
        {
            return _context.TbThietBiPtnThtren500Trs.Any(e => e.IdThietBiPtnTh == id);
        }
    }
}
