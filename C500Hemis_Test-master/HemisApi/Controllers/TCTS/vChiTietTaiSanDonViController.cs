using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.TCTS
{
    [Route("api/tcts/[controller]")]
    [ApiController]
    public class vChiTietTaiSanDonViController : ControllerBase
    {
        private readonly HemisContext _context;

        public vChiTietTaiSanDonViController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VChiTietTaiSanDonVi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VChiTietTaiSanDonVi>>> GetVChiTietTaiSanDonVis()
        {
            return await _context.VChiTietTaiSanDonVis.ToListAsync();
        }

        // GET: api/VChiTietTaiSanDonVi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VChiTietTaiSanDonVi>> GetVChiTietTaiSanDonVi(int id)
        {
            var VChiTietTaiSanDonVi = await _context.VChiTietTaiSanDonVis.FindAsync(id);

            if (VChiTietTaiSanDonVi == null)
            {
                return NotFound();
            }

            return VChiTietTaiSanDonVi;
        }

    }
}
