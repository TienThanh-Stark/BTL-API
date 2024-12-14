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
    public class TinhTrangGiangVienDuocCuDiDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public TinhTrangGiangVienDuocCuDiDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTinhTrangGiangVienDuocCuDiDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTinhTrangGiangVienDuocCuDiDaoTao>>> GetDmTinhTrangGiangVienDuocCuDiDaoTaos()
        {
            return await _context.DmTinhTrangGiangVienDuocCuDiDaoTaos.ToListAsync();
        }

        // GET: api/DmTinhTrangGiangVienDuocCuDiDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTinhTrangGiangVienDuocCuDiDaoTao>> GetDmTinhTrangGiangVienDuocCuDiDaoTao(int id)
        {
            var dmTinhTrangGiangVienDuocCuDiDaoTao = await _context.DmTinhTrangGiangVienDuocCuDiDaoTaos.FindAsync(id);

            if (dmTinhTrangGiangVienDuocCuDiDaoTao == null)
            {
                return NotFound();
            }

            return dmTinhTrangGiangVienDuocCuDiDaoTao;
        }

        private bool DmTinhTrangGiangVienDuocCuDiDaoTaoExists(int id)
        {
            return _context.DmTinhTrangGiangVienDuocCuDiDaoTaos.Any(e => e.IdTinhTrangGiangVienDuocCuDiDaoTao == id);
        }
    }
}
