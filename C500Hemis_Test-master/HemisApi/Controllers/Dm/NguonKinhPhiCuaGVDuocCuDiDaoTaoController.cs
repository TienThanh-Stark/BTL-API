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
    public class NguonKinhPhiCuaGvduocCuDiDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public NguonKinhPhiCuaGvduocCuDiDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmNguonKinhPhiCuaGvduocCuDiDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmNguonKinhPhiCuaGvduocCuDiDaoTao>>> GetDmNguonKinhPhiCuaGvduocCuDiDaoTaos()
        {
            return await _context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos.ToListAsync();
        }

        // GET: api/DmNguonKinhPhiCuaGvduocCuDiDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmNguonKinhPhiCuaGvduocCuDiDaoTao>> GetDmNguonKinhPhiCuaGvduocCuDiDaoTao(int id)
        {
            var dmNguonKinhPhiCuaGvduocCuDiDaoTao = await _context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos.FindAsync(id);

            if (dmNguonKinhPhiCuaGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }

            return dmNguonKinhPhiCuaGvduocCuDiDaoTao;
        }

        private bool DmNguonKinhPhiCuaGvduocCuDiDaoTaoExists(int id)
        {
            return _context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos.Any(e => e.IdNguonKinhPhiCuaGvduocCuDiDaoTao == id);
        }
    }
}
