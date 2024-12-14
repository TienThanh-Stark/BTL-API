using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CTDT
{
    [Route("api/ctdt/[controller]")]
    [ApiController]
    public class HinhThucDaoTaoCuaNganhController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucDaoTaoCuaNganhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHinhThucDaoTaoCuaNganh>>> GetTbHinhThucDaoTaoCuaNganhs()
        {
            return await _context.TbHinhThucDaoTaoCuaNganhs.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHinhThucDaoTaoCuaNganh>> GetTbHinhThucDaoTaoCuaNganh(int id)
        {
            var TbHinhThucDaoTaoCuaNganh = await _context.TbHinhThucDaoTaoCuaNganhs.FindAsync(id);

            if (TbHinhThucDaoTaoCuaNganh == null)
            {
                return NotFound();
            }

            return TbHinhThucDaoTaoCuaNganh;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHinhThucDaoTaoCuaNganh(int id, TbHinhThucDaoTaoCuaNganh TbHinhThucDaoTaoCuaNganh)
        {
            if (id != TbHinhThucDaoTaoCuaNganh.IdHinhThucDaoTaoCuaNganh)
            {
                return BadRequest();
            }

            _context.Entry(TbHinhThucDaoTaoCuaNganh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHinhThucDaoTaoCuaNganhExists(id))
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
        public async Task<ActionResult<TbHinhThucDaoTaoCuaNganh>> PostTbHinhThucDaoTaoCuaNganh(TbHinhThucDaoTaoCuaNganh TbHinhThucDaoTaoCuaNganh)
        {
            _context.TbHinhThucDaoTaoCuaNganhs.Add(TbHinhThucDaoTaoCuaNganh);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbHinhThucDaoTaoCuaNganhExists(TbHinhThucDaoTaoCuaNganh.IdHinhThucDaoTaoCuaNganh))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbHinhThucDaoTaoCuaNganh", new { id = TbHinhThucDaoTaoCuaNganh.IdHinhThucDaoTaoCuaNganh }, TbHinhThucDaoTaoCuaNganh);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbHinhThucDaoTaoCuaNganh(int id)
        {
            var TbHinhThucDaoTaoCuaNganh = await _context.TbHinhThucDaoTaoCuaNganhs.FindAsync(id);
            if (TbHinhThucDaoTaoCuaNganh == null)
            {
                return NotFound();
            }

            _context.TbHinhThucDaoTaoCuaNganhs.Remove(TbHinhThucDaoTaoCuaNganh);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbHinhThucDaoTaoCuaNganhExists(int id)
        {
            return _context.TbHinhThucDaoTaoCuaNganhs.Any(e => e.IdHinhThucDaoTaoCuaNganh == id);
        }
    }
}
