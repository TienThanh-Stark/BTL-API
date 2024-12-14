using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CTDT
{
    [Route("api/ctdt/[controller]")]
    [ApiController]
    public class vThongTinKiemDinhCuaChuongTrinhController : ControllerBase
    {
        private readonly HemisContext _context;

        public vThongTinKiemDinhCuaChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VThongTinKiemDinhCuaChuongTrinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VThongTinKiemDinhCuaChuongTrinh>>> GetVThongTinKiemDinhCuaChuongTrinhs()
        {
            return await _context.VThongTinKiemDinhCuaChuongTrinhs.ToListAsync();
        }

        // GET: api/VThongTinKiemDinhCuaChuongTrinh/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VThongTinKiemDinhCuaChuongTrinh>> GetVThongTinKiemDinhCuaChuongTrinh(int id)
        {
            var VThongTinKiemDinhCuaChuongTrinh = await _context.VThongTinKiemDinhCuaChuongTrinhs.FindAsync(id);

            if (VThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }

            return VThongTinKiemDinhCuaChuongTrinh;
        }

     
    }
}
