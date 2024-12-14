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
    public class TinhTrangCoSoVatChatController : ControllerBase
    {
        private readonly HemisContext _context;

        public TinhTrangCoSoVatChatController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmTinhTrangCoSoVatChat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmTinhTrangCoSoVatChat>>> GetDmTinhTrangCoSoVatChats()
        {
            return await _context.DmTinhTrangCoSoVatChats.ToListAsync();
        }

        // GET: api/DmTinhTrangCoSoVatChat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmTinhTrangCoSoVatChat>> GetDmTinhTrangCoSoVatChat(int id)
        {
            var dmTinhTrangCoSoVatChat = await _context.DmTinhTrangCoSoVatChats.FindAsync(id);

            if (dmTinhTrangCoSoVatChat == null)
            {
                return NotFound();
            }

            return dmTinhTrangCoSoVatChat;
        }

        private bool DmTinhTrangCoSoVatChatExists(int id)
        {
            return _context.DmTinhTrangCoSoVatChats.Any(e => e.IdTinhTrangCoSoVatChat == id);
        }
    }
}
