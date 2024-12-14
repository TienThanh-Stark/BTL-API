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
    public class vThongTinNguoiHocGDTCController : ControllerBase
    {
        private readonly HemisContext _context;

        public vThongTinNguoiHocGDTCController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VThongTinNguoiHocGDTC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VThongTinNguoiHocGdtc>>> GetVThongTinNguoiHocGDTCs()
        {
            return await _context.VThongTinNguoiHocGdtcs.ToListAsync();
        }

        // GET: api/VThongTinNguoiHocGDTC/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VThongTinNguoiHocGdtc>> GetVThongTinNguoiHocGDTC(int id)
        {
            var VThongTinNguoiHocGDTC = await _context.VThongTinNguoiHocGdtcs.FindAsync(id);

            if (VThongTinNguoiHocGDTC == null)
            {
                return NotFound();
            }

            return VThongTinNguoiHocGDTC;
        }

    
    }
}
