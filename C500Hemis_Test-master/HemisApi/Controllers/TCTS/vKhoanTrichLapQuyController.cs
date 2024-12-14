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
    public class vKhoanTrichLapQuyController : ControllerBase
    {
        private readonly HemisContext _context;

        public vKhoanTrichLapQuyController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VKhoanTrichLapQuy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VKhoanTrichLapQuy>>> GetVKhoanTrichLapQuys()
        {
            return await _context.VKhoanTrichLapQuies.ToListAsync();
        }

        // GET: api/VKhoanTrichLapQuy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VKhoanTrichLapQuy>> GetVKhoanTrichLapQuy(int id)
        {
            var VKhoanTrichLapQuy = await _context.VKhoanTrichLapQuies.FindAsync(id);

            if (VKhoanTrichLapQuy == null)
            {
                return NotFound();
            }

            return VKhoanTrichLapQuy;
        }

    }
}
