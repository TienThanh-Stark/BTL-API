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
    public class LoaiCongTrinhCoSoVatChatController : ControllerBase
    {
        private readonly HemisContext _context;

        public LoaiCongTrinhCoSoVatChatController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/DmLoaiCongTrinhCoSoVatChat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DmLoaiCongTrinhCoSoVatChat>>> GetDmLoaiCongTrinhCoSoVatChats()
        {
            return await _context.DmLoaiCongTrinhCoSoVatChats.ToListAsync();
        }

        // GET: api/DmLoaiCongTrinhCoSoVatChat/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DmLoaiCongTrinhCoSoVatChat>> GetDmLoaiCongTrinhCoSoVatChat(int id)
        {
            var dmLoaiCongTrinhCoSoVatChat = await _context.DmLoaiCongTrinhCoSoVatChats.FindAsync(id);

            if (dmLoaiCongTrinhCoSoVatChat == null)
            {
                return NotFound();
            }

            return dmLoaiCongTrinhCoSoVatChat;
        }

        private bool DmLoaiCongTrinhCoSoVatChatExists(int id)
        {
            return _context.DmLoaiCongTrinhCoSoVatChats.Any(e => e.IdLoaiCongTrinhCoSoVatChat == id);
        }
    }
}
