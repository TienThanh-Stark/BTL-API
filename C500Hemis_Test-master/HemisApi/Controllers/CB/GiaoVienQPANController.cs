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
    public class GiaoVienQPANController : ControllerBase
    {
        private readonly HemisContext _context;

        public GiaoVienQPANController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGiaoVienQpan>>> GetTbGiaoVienQpans()
        {
            return await _context.TbGiaoVienQpans.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGiaoVienQpan>> GetTbGiaoVienQpan(int id)
        {
            var TbGiaoVienQpan = await _context.TbGiaoVienQpans.FindAsync(id);

            if (TbGiaoVienQpan == null)
            {
                return NotFound();
            }

            return TbGiaoVienQpan;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGiaoVienQpan(int id, TbGiaoVienQpan TbGiaoVienQpan)
        {
            if (id != TbGiaoVienQpan.IdGiaoVienQpan)
            {
                return BadRequest();
            }

            _context.Entry(TbGiaoVienQpan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGiaoVienQpanExists(id))
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
        public async Task<ActionResult<TbGiaoVienQpan>> PostTbGiaoVienQpan(TbGiaoVienQpan TbGiaoVienQpan)
        {
            _context.TbGiaoVienQpans.Add(TbGiaoVienQpan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbGiaoVienQpanExists(TbGiaoVienQpan.IdGiaoVienQpan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbGiaoVienQpan", new { id = TbGiaoVienQpan.IdGiaoVienQpan }, TbGiaoVienQpan);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGiaoVienQpan(int id)
        {
            var TbGiaoVienQpan = await _context.TbGiaoVienQpans.FindAsync(id);
            if (TbGiaoVienQpan == null)
            {
                return NotFound();
            }

            _context.TbGiaoVienQpans.Remove(TbGiaoVienQpan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGiaoVienQpanExists(int id)
        {
            return _context.TbGiaoVienQpans.Any(e => e.IdGiaoVienQpan == id);
        }
    }
}
