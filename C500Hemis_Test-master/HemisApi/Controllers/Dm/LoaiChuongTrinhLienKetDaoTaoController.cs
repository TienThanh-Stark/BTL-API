using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.Dm
{
    [Route("api/dm/[controller]")]
    [ApiController]
    public class LoaiChuongTrinhLienKetDaoTaoController: ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiChuongTrinhLienKetDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiChuongTrinhLienKetDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiChuongTrinhLienKetDaoTao>>> GetDmLoaiChuongTrinhLienKetDaoTaos()
        {
            return await _context.DmLoaiChuongTrinhLienKetDaoTaos.ToListAsync();
        }

        // GET: api/DmLoaiChuongTrinhLienKetDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiChuongTrinhLienKetDaoTao>> GetDmLoaiChuongTrinhLienKetDaoTao(int id)
        {
            var dmLoaiChuongTrinhLienKetDaoTao = await _context.DmLoaiChuongTrinhLienKetDaoTaos.FindAsync(id);

            if (dmLoaiChuongTrinhLienKetDaoTao == null)
            {
                return NotFound();
            }

            return dmLoaiChuongTrinhLienKetDaoTao;
        }

        private bool DmLoaiChuongTrinhLienKetDaoTaoExists(int id)
        {
            return _context.DmLoaiChuongTrinhLienKetDaoTaos.Any(e => e.IdLoaiChuongTrinhLienKetDaoTao == id);
        }
    }
}
