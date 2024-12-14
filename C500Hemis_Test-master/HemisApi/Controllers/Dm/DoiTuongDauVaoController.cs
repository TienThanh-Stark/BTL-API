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
    public class DoiTuongDauVaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public DoiTuongDauVaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmDoiTuongDauVao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmDoiTuongDauVao>>> GetDmDoiTuongDauVaos()
        {
            return await _context.DmDoiTuongDauVaos.ToListAsync();
        }

        // GET: api/DmDoiTuongDauVao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmDoiTuongDauVao>> GetDmDoiTuongDauVao(int id)
        {
            var dmDoiTuongDauVao = await _context.DmDoiTuongDauVaos.FindAsync(id);

            if (dmDoiTuongDauVao == null)
            {
                return NotFound();
            }

            return dmDoiTuongDauVao;
        }

        private bool DmDoiTuongDauVaoExists(int id)
        {
            return _context.DmDoiTuongDauVaos.Any(e => e.IdDoiTuongDauVao == id);
        }
    }
}
