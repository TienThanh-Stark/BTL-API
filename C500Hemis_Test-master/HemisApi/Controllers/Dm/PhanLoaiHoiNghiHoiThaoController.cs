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
    public class PhanLoaiHoiNghiHoiThaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public PhanLoaiHoiNghiHoiThaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmPhanLoaiHoiNghiHoiThao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmPhanLoaiHoiNghiHoiThao>>> GetDmPhanLoaiHoiNghiHoiThaos()
        {
            return await _context.DmPhanLoaiHoiNghiHoiThaos.ToListAsync();
        }

        // GET: api/DmPhanLoaiHoiNghiHoiThao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmPhanLoaiHoiNghiHoiThao>> GetDmPhanLoaiHoiNghiHoiThao(int id)
        {
            var dmPhanLoaiHoiNghiHoiThao = await _context.DmPhanLoaiHoiNghiHoiThaos.FindAsync(id);

            if (dmPhanLoaiHoiNghiHoiThao == null)
            {
                return NotFound();
            }

            return dmPhanLoaiHoiNghiHoiThao;
        }

        private bool DmPhanLoaiHoiNghiHoiThaoExists(int id)
        {
            return _context.DmPhanLoaiHoiNghiHoiThaos.Any(e => e.IdPhanLoaiHoiNghiHoiThao == id);
        }
    }
}
