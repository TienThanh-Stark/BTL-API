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
    public class QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiController : ControllerBase
    {
        private readonly HemisContext _context;

        public QuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>>> GetTbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais()
        {
            return await _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>> GetTbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai(int id)
        {
            var TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai = await _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.FindAsync(id);

            if (TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == null)
            {
                return NotFound();
            }

            return TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai(int id, TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai)
        {
            if (id != TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai)
            {
                return BadRequest();
            }

            _context.Entry(TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiExists(id))
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
        public async Task<ActionResult<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>> PostTbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai(TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai)
        {
            _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.Add(TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiExists(TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai", new { id = TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai }, TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai(int id)
        {
            var TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai = await _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.FindAsync(id);
            if (TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == null)
            {
                return NotFound();
            }

            _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.Remove(TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoaiExists(int id)
        {
            return _context.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais.Any(e => e.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai == id);
        }
    }
}
