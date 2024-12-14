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
    public class PhanLoaiDoanRaDoanVaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhanLoaiDoanRaDoanVaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmPhanLoaiDoanRaDoanVao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhanLoaiDoanRaDoanVao>>> GetDmPhanLoaiDoanRaDoanVaos()
        {
            return await _context.DmPhanLoaiDoanRaDoanVaos.ToListAsync();
        }

        // GET: api/DmPhanLoaiDoanRaDoanVao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhanLoaiDoanRaDoanVao>> GetDmPhanLoaiDoanRaDoanVao(int id)
        {
            var dmPhanLoaiDoanRaDoanVao = await _context.DmPhanLoaiDoanRaDoanVaos.FindAsync(id);

            if (dmPhanLoaiDoanRaDoanVao == null)
            {
                return NotFound();
            }

            return dmPhanLoaiDoanRaDoanVao;
        }

        private bool DmPhanLoaiDoanRaDoanVaoExists(int id)
        {
            return _context.DmPhanLoaiDoanRaDoanVaos.Any(e => e.IdPhanLoaiDoanRaDoanVao == id);
        }
    }
}
