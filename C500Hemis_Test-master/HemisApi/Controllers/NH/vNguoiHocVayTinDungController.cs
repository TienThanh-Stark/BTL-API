using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.NH
{
    [Route("api/nh/[controller]")]
    [ApiController]
    public class vNguoiHocVayTinDungController : ControllerBase
    {
        private readonly HemisContext _context;

        public vNguoiHocVayTinDungController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VNguoiHocVayTinDung
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VNguoiHocVayTinDung>>> GetVNguoiHocVayTinDungs()
        {
            return await _context.VNguoiHocVayTinDungs.ToListAsync();
        }

        // GET: api/VNguoiHocVayTinDung/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VNguoiHocVayTinDung>> GetVNguoiHocVayTinDung(int id)
        {
            var VNguoiHocVayTinDung = await _context.VNguoiHocVayTinDungs.FindAsync(id);

            if (VNguoiHocVayTinDung == null)
            {
                return NotFound();
            }

            return VNguoiHocVayTinDung;
        }

    
    }
}
