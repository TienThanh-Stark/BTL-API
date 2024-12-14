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
    public class vThongTinViPhamController : ControllerBase
    {
        private readonly HemisContext _context;

        public vThongTinViPhamController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VThongTinViPham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VThongTinViPham>>> GetVThongTinViPhams()
        {
            return await _context.VThongTinViPhams.ToListAsync();
        }

        // GET: api/VThongTinViPham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VThongTinViPham>> GetVThongTinViPham(int id)
        {
            var VThongTinViPham = await _context.VThongTinViPhams.FindAsync(id);

            if (VThongTinViPham == null)
            {
                return NotFound();
            }

            return VThongTinViPham;
        }

       
    }
}
