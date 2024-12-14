using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSGD
{
    [Route("api/csgd/[controller]")]
    [ApiController]
    public class vLichSuDoiTenTruongController : ControllerBase
    {
        private readonly HemisContext _context;

        public vLichSuDoiTenTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VLichSuDoiTenTruong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VLichSuDoiTenTruong>>> GetVLichSuDoiTenTruongs()
        {
            return await _context.VLichSuDoiTenTruongs.ToListAsync();
        }

        // GET: api/VLichSuDoiTenTruong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VLichSuDoiTenTruong>> GetVLichSuDoiTenTruong(int id)
        {
            var VLichSuDoiTenTruong = await _context.VLichSuDoiTenTruongs.FindAsync(id);

            if (VLichSuDoiTenTruong == null)
            {
                return NotFound();
            }

            return VLichSuDoiTenTruong;
        }

        
    }
}
