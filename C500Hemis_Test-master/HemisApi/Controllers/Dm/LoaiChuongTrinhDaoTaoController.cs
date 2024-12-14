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
    public class LoaiChuongTrinhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiChuongTrinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiChuongTrinhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiChuongTrinhDaoTao>>> GetDmLoaiChuongTrinhDaoTaos()
        {
            return await _context.DmLoaiChuongTrinhDaoTaos.ToListAsync();
        }

        // GET: api/DmLoaiChuongTrinhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiChuongTrinhDaoTao>> GetDmLoaiChuongTrinhDaoTao(int id)
        {
            var dmLoaiChuongTrinhDaoTao = await _context.DmLoaiChuongTrinhDaoTaos.FindAsync(id);

            if (dmLoaiChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return dmLoaiChuongTrinhDaoTao;
        }

        private bool DmLoaiChuongTrinhDaoTaoExists(int id)
        {
            return _context.DmLoaiChuongTrinhDaoTaos.Any(e => e.IdLoaiChuongTrinhDaoTao == id);
        }
    }
}
