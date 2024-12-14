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
    public class NoiDungHoatDongController : ControllerBase
    {
        private readonly HemisContext _context;

        public NoiDungHoatDongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNoiDungHoatDong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNoiDungHoatDong>>> GetDmNoiDungHoatDongs()
        {
            return await _context.DmNoiDungHoatDongs.ToListAsync();
        }

        // GET: api/DmNoiDungHoatDong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNoiDungHoatDong>> GetDmNoiDungHoatDong(int id)
        {
            var dmNoiDungHoatDong = await _context.DmNoiDungHoatDongs.FindAsync(id);

            if (dmNoiDungHoatDong == null)
            {
                return NotFound();
            }

            return dmNoiDungHoatDong;
        }

        private bool DmNoiDungHoatDongExists(int id)
        {
            return _context.DmNoiDungHoatDongs.Any(e => e.IdNoiDungHoatDong == id);
        }
    }
}
