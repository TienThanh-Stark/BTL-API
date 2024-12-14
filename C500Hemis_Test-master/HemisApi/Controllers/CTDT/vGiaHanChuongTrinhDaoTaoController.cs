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
    public class vGiaHanChuongTrinhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public vGiaHanChuongTrinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VGiaHanChuongTrinhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VGiaHanChuongTrinhDaoTao>>> GetVGiaHanChuongTrinhDaoTaos()
        {
            return await _context.VGiaHanChuongTrinhDaoTaos.ToListAsync();
        }

        // GET: api/VGiaHanChuongTrinhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VGiaHanChuongTrinhDaoTao>> GetVGiaHanChuongTrinhDaoTao(int id)
        {
            var VGiaHanChuongTrinhDaoTao = await _context.VGiaHanChuongTrinhDaoTaos.FindAsync(id);

            if (VGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return VGiaHanChuongTrinhDaoTao;
        }

    }
}
