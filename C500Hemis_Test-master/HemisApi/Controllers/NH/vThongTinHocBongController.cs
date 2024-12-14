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
    public class vThongTinHocBongController : ControllerBase
    {
        private readonly HemisContext _context;

        public vThongTinHocBongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VThongTinHocBong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VThongTinHocBong>>> GetVThongTinHocBongs()
        {
            return await _context.VThongTinHocBongs.ToListAsync();
        }

        // GET: api/VThongTinHocBong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VThongTinHocBong>> GetVThongTinHocBong(int id)
        {
            var VThongTinHocBong = await _context.VThongTinHocBongs.FindAsync(id);

            if (VThongTinHocBong == null)
            {
                return NotFound();
            }

            return VThongTinHocBong;
        }

      
    }
}
