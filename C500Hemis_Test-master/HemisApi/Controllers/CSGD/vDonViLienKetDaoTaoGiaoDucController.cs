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
    public class vDonViLienKetDaoTaoGiaoDucController : ControllerBase
    {
        private readonly HemisContext _context;

        public vDonViLienKetDaoTaoGiaoDucController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VDonViLienKetDaoTaoGiaoDuc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VDonViLienKetDaoTaoGiaoDuc>>> GetVDonViLienKetDaoTaoGiaoDucs()
        {
            return await _context.VDonViLienKetDaoTaoGiaoDucs.ToListAsync();
        }

        // GET: api/VDonViLienKetDaoTaoGiaoDuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VDonViLienKetDaoTaoGiaoDuc>> GetVDonViLienKetDaoTaoGiaoDuc(int id)
        {
            var VDonViLienKetDaoTaoGiaoDuc = await _context.VDonViLienKetDaoTaoGiaoDucs.FindAsync(id);

            if (VDonViLienKetDaoTaoGiaoDuc == null)
            {
                return NotFound();
            }

            return VDonViLienKetDaoTaoGiaoDuc;
        }

        
    }
}
