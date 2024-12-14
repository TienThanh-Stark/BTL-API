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
    public class TrangThaiDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public TrangThaiDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTrangThaiDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTrangThaiDaoTao>>> GetDmTrangThaiDaoTaos()
        {
            return await _context.DmTrangThaiDaoTaos.ToListAsync();
        }

        // GET: api/DmTrangThaiDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTrangThaiDaoTao>> GetDmTrangThaiDaoTao(int id)
        {
            var dmTrangThaiDaoTao = await _context.DmTrangThaiDaoTaos.FindAsync(id);

            if (dmTrangThaiDaoTao == null)
            {
                return NotFound();
            }

            return dmTrangThaiDaoTao;
        }

        private bool DmTrangThaiDaoTaoExists(int id)
        {
            return _context.DmTrangThaiDaoTaos.Any(e => e.IdTrangThaiDaoTao == id);
        }
    }
}
