using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.NDT
{
    [Route("api/ndt/[controller]")]
    [ApiController]
    public class vThongTinLinhVucDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public vThongTinLinhVucDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VThongTinLinhVucDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VThongTinLinhVucDaoTao>>> GetVThongTinLinhVucDaoTaos()
        {
            return await _context.VThongTinLinhVucDaoTaos.ToListAsync();
        }

        // GET: api/VThongTinLinhVucDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VThongTinLinhVucDaoTao>> GetVThongTinLinhVucDaoTao(int id)
        {
            var VThongTinLinhVucDaoTao = await _context.VThongTinLinhVucDaoTaos.FindAsync(id);

            if (VThongTinLinhVucDaoTao == null)
            {
                return NotFound();
            }

            return VThongTinLinhVucDaoTao;
        }

      
    }
}
