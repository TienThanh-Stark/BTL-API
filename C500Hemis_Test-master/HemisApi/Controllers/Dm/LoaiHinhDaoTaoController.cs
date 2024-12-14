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
    public class LoaiHinhDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiHinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiHinhDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiHinhDaoTao>>> GetDmLoaiHinhDaoTaos()
        {
            return await _context.DmLoaiHinhDaoTaos.ToListAsync();
        }

        // GET: api/DmLoaiHinhDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiHinhDaoTao>> GetDmLoaiHinhDaoTao(int id)
        {
            var dmLoaiHinhDaoTao = await _context.DmLoaiHinhDaoTaos.FindAsync(id);

            if (dmLoaiHinhDaoTao == null)
            {
                return NotFound();
            }

            return dmLoaiHinhDaoTao;
        }

        private bool DmLoaiHinhDaoTaoExists(int id)
        {
            return _context.DmLoaiHinhDaoTaos.Any(e => e.IdLoaiHinhDaoTao == id);
        }
    }
}
