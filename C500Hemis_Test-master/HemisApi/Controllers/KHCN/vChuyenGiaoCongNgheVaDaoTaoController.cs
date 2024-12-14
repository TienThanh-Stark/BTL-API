using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.KHCN
{
    [Route("api/khcn/[controller]")]
    [ApiController]
    public class vChuyenGiaoCongNgheVaDaoTaoController : ControllerBase
    {
        private readonly HemisContext _context;

        public vChuyenGiaoCongNgheVaDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/VChuyenGiaoCongNgheVaDaoTao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VChuyenGiaoCongNgheVaDaoTao>>> GetVChuyenGiaoCongNgheVaDaoTaos()
        {
            return await _context.VChuyenGiaoCongNgheVaDaoTaos.ToListAsync();
        }

        // GET: api/VChuyenGiaoCongNgheVaDaoTao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VChuyenGiaoCongNgheVaDaoTao>> GetVChuyenGiaoCongNgheVaDaoTao(int id)
        {
            var VChuyenGiaoCongNgheVaDaoTao = await _context.VChuyenGiaoCongNgheVaDaoTaos.FindAsync(id);

            if (VChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }

            return VChuyenGiaoCongNgheVaDaoTao;
        }

    }
}
