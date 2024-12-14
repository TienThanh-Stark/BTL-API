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
    public class PhanLoaiCoSoController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhanLoaiCoSoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmPhanLoaiCoSo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhanLoaiCoSo>>> GetDmPhanLoaiCoSos()
        {
            return await _context.DmPhanLoaiCoSos.ToListAsync();
        }

        // GET: api/DmPhanLoaiCoSo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhanLoaiCoSo>> GetDmPhanLoaiCoSo(int id)
        {
            var dmPhanLoaiCoSo = await _context.DmPhanLoaiCoSos.FindAsync(id);

            if (dmPhanLoaiCoSo == null)
            {
                return NotFound();
            }

            return dmPhanLoaiCoSo;
        }

        private bool DmPhanLoaiCoSoExists(int id)
        {
            return _context.DmPhanLoaiCoSos.Any(e => e.IdPhanLoaiCoSo == id);
        }
    }
}
