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
    public class PhongThucHanhController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhongThucHanhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPhongThucHanh>>> GetTbPhongThucHanhs()
        {
            return await _context.TbPhongThucHanhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPhongThucHanh>> GetTbPhongThucHanh(int id)
        {
            var TbPhongThucHanh = await _context.TbPhongThucHanhs.FindAsync(id);

            if (TbPhongThucHanh == null)
            {
                return NotFound();
            }

            return TbPhongThucHanh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPhongThucHanh(int id, TbPhongThucHanh TbPhongThucHanh)
        {
            if (id != TbPhongThucHanh.IdPhongThucHanh)
            {
                return BadRequest();
            }

            _context.Entry(TbPhongThucHanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPhongThucHanhExists(id))
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
        public async Task<ActionResult<TbPhongThucHanh>> PostTbPhongThucHanh(TbPhongThucHanh TbPhongThucHanh)
        {
            _context.TbPhongThucHanhs.Add(TbPhongThucHanh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbPhongThucHanhExists(TbPhongThucHanh.IdPhongThucHanh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbPhongThucHanh", new { id = TbPhongThucHanh.IdPhongThucHanh }, TbPhongThucHanh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPhongThucHanh(int id)
        {
            var TbPhongThucHanh = await _context.TbPhongThucHanhs.FindAsync(id);
            if (TbPhongThucHanh == null)
            {
                return NotFound();
            }

            _context.TbPhongThucHanhs.Remove(TbPhongThucHanh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPhongThucHanhExists(int id)
        {
            return _context.TbPhongThucHanhs.Any(e => e.IdPhongThucHanh == id);
        }
    }
}
