using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSGD
{
    [Route("api/csgd/[controller]")]
    [ApiController]
    public class CoSoGiaoDucController : ControllerBase
    {
        private readonly HemisContext _context;

        public CoSoGiaoDucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCoSoGiaoDuc>>> GetTbCoSoGiaoDucs()
        {
            return await _context.TbCoSoGiaoDucs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCoSoGiaoDuc>> GetTbCoSoGiaoDuc(int id)
        {
            var TbCoSoGiaoDuc = await _context.TbCoSoGiaoDucs.FindAsync(id);

            if (TbCoSoGiaoDuc == null)
            {
                return NotFound();
            }

            return TbCoSoGiaoDuc;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCoSoGiaoDuc(int id, TbCoSoGiaoDuc TbCoSoGiaoDuc)
        {
            if (id != TbCoSoGiaoDuc.IdCoSoGiaoDuc)
            {
                return BadRequest();
            }

            _context.Entry(TbCoSoGiaoDuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCoSoGiaoDucExists(id))
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
        public async Task<ActionResult<TbCoSoGiaoDuc>> PostTbCoSoGiaoDuc(TbCoSoGiaoDuc TbCoSoGiaoDuc)
        {
            _context.TbCoSoGiaoDucs.Add(TbCoSoGiaoDuc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbCoSoGiaoDucExists(TbCoSoGiaoDuc.IdCoSoGiaoDuc))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbCoSoGiaoDuc", new { id = TbCoSoGiaoDuc.IdCoSoGiaoDuc }, TbCoSoGiaoDuc);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCoSoGiaoDuc(int id)
        {
            var TbCoSoGiaoDuc = await _context.TbCoSoGiaoDucs.FindAsync(id);
            if (TbCoSoGiaoDuc == null)
            {
                return NotFound();
            }

            _context.TbCoSoGiaoDucs.Remove(TbCoSoGiaoDuc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCoSoGiaoDucExists(int id)
        {
            return _context.TbCoSoGiaoDucs.Any(e => e.IdCoSoGiaoDuc == id);
        }
    }
}
