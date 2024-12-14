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
    public class TrangThaiChuongTrinhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrangThaiChuongTrinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrangThaiChuongTrinhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrangThaiChuongTrinhDaoTao>>> GetDmTrangThaiChuongTrinhDaoTaos()
        {
            return await _context.DmTrangThaiChuongTrinhDaoTaos.ToListAsync();
        }

        // GET: api/DmTrangThaiChuongTrinhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrangThaiChuongTrinhDaoTao>> GetDmTrangThaiChuongTrinhDaoTao(int id)
        {
            var dmTrangThaiChuongTrinhDaoTao = await _context.DmTrangThaiChuongTrinhDaoTaos.FindAsync(id);

            if (dmTrangThaiChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return dmTrangThaiChuongTrinhDaoTao;
        }

        private bool DmTrangThaiChuongTrinhDaoTaoExists(int id)
        {
            return _context.DmTrangThaiChuongTrinhDaoTaos.Any(e => e.IdTrangThaiChuongTrinhDaoTao == id);
        }
    }
}
