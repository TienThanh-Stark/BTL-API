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
    public class NoiDungHoatDongTaiVietNamController : ControllerBase
    {
        private readonly HemisContext _context;

        public NoiDungHoatDongTaiVietNamController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNoiDungHoatDongTaiVietNam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNoiDungHoatDongTaiVietNam>>> GetDmNoiDungHoatDongTaiVietNams()
        {
            return await _context.DmNoiDungHoatDongTaiVietNams.ToListAsync();
        }

        // GET: api/DmNoiDungHoatDongTaiVietNam/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNoiDungHoatDongTaiVietNam>> GetDmNoiDungHoatDongTaiVietNam(int id)
        {
            var dmNoiDungHoatDongTaiVietNam = await _context.DmNoiDungHoatDongTaiVietNams.FindAsync(id);

            if (dmNoiDungHoatDongTaiVietNam == null)
            {
                return NotFound();
            }

            return dmNoiDungHoatDongTaiVietNam;
        }

        private bool DmNoiDungHoatDongTaiVietNamExists(int id)
        {
            return _context.DmNoiDungHoatDongTaiVietNams.Any(e => e.IdNoiDungHoatDongTaiVietNam == id);
        }
    }
}
