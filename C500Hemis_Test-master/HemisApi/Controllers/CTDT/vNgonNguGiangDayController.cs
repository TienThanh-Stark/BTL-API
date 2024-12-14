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
    public class vNgonNguGiangDayController : ControllerBase
    {
        private readonly HemisContext _context;

        public vNgonNguGiangDayController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VNgonNguGiangDay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VNgonNguGiangDay>>> GetVNgonNguGiangDays()
        {
            return await _context.VNgonNguGiangDays.ToListAsync();
        }

        // GET: api/VNgonNguGiangDay/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VNgonNguGiangDay>> GetVNgonNguGiangDay(int id)
        {
            var VNgonNguGiangDay = await _context.VNgonNguGiangDays.FindAsync(id);

            if (VNgonNguGiangDay == null)
            {
                return NotFound();
            }

            return VNgonNguGiangDay;
        }

    }
}
