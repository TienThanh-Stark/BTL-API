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
    public class vKhoiNganhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public vKhoiNganhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VKhoiNganhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VKhoiNganhDaoTao>>> GetVKhoiNganhDaoTaos()
        {
            return await _context.VKhoiNganhDaoTaos.ToListAsync();
        }

        // GET: api/VKhoiNganhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VKhoiNganhDaoTao>> GetVKhoiNganhDaoTao(int id)
        {
            var VKhoiNganhDaoTao = await _context.VKhoiNganhDaoTaos.FindAsync(id);

            if (VKhoiNganhDaoTao == null)
            {
                return NotFound();
            }

            return VKhoiNganhDaoTao;
        }

    }
}
