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
    public class HinhThucThamGiaGvduocCuDiDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public HinhThucThamGiaGvduocCuDiDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmHinhThucThamGiaGvduocCuDiDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmHinhThucThamGiaGvduocCuDiDaoTao>>> GetDmHinhThucThamGiaGvduocCuDiDaoTaos()
        {
            return await _context.DmHinhThucThamGiaGvduocCuDiDaoTaos.ToListAsync();
        }

        // GET: api/DmHinhThucThamGiaGvduocCuDiDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmHinhThucThamGiaGvduocCuDiDaoTao>> GetDmHinhThucThamGiaGvduocCuDiDaoTao(int id)
        {
            var dmHinhThucThamGiaGvduocCuDiDaoTao = await _context.DmHinhThucThamGiaGvduocCuDiDaoTaos.FindAsync(id);

            if (dmHinhThucThamGiaGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }

            return dmHinhThucThamGiaGvduocCuDiDaoTao;
        }

        private bool DmHinhThucThamGiaGvduocCuDiDaoTaoExists(int id)
        {
            return _context.DmHinhThucThamGiaGvduocCuDiDaoTaos.Any(e => e.IdHinhThucThamGiaGvduocCuDiDaoTao == id);
        }
    }
}
