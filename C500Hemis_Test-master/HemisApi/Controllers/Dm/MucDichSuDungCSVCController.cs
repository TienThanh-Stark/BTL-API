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
    public class MucDichSuDungCsvcController : ControllerBase
    {
        private readonly HemisContext _context;

        public MucDichSuDungCsvcController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmMucDichSuDungCsvc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmMucDichSuDungCsvc>>> GetDmMucDichSuDungCsvcs()
        {
            return await _context.DmMucDichSuDungCsvcs.ToListAsync();
        }

        // GET: api/DmMucDichSuDungCsvc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmMucDichSuDungCsvc>> GetDmMucDichSuDungCsvc(int id)
        {
            var dmMucDichSuDungCsvc = await _context.DmMucDichSuDungCsvcs.FindAsync(id);

            if (dmMucDichSuDungCsvc == null)
            {
                return NotFound();
            }

            return dmMucDichSuDungCsvc;
        }

        private bool DmMucDichSuDungCsvcExists(int id)
        {
            return _context.DmMucDichSuDungCsvcs.Any(e => e.IdMucDichSuDungCsvc == id);
        }
    }
}
