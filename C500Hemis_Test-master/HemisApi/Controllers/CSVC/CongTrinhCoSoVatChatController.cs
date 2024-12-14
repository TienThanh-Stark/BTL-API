using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using C500Hemis;

namespace HemisApi.Controllers.CSVC
{
    [Route("api/csvc/[controller]")]
    [ApiController]
    public class CongTrinhCoSoVatChatController : ControllerBase
    {
        private readonly HemisContext _context;

        public CongTrinhCoSoVatChatController(HemisContext context)
        {
            _context = context;
        }

        // GET: api/CanBo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCongTrinhCoSoVatChat>>> GetTbCongTrinhCoSoVatChats()
        {
            return await _context.TbCongTrinhCoSoVatChats.ToListAsync();
        }

        // GET: api/CanBo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCongTrinhCoSoVatChat>> GetTbCongTrinhCoSoVatChat(int id)
        {
            var TbCongTrinhCoSoVatChat = await _context.TbCongTrinhCoSoVatChats.FindAsync(id);

            if (TbCongTrinhCoSoVatChat == null)
            {
                return NotFound();
            }

            return TbCongTrinhCoSoVatChat;
        }

        // PUT: api/CanBo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCongTrinhCoSoVatChat(int id, TbCongTrinhCoSoVatChat TbCongTrinhCoSoVatChat)
        {
            if (id != TbCongTrinhCoSoVatChat.IdCongTrinhCoSoVatChat)
            {
                return BadRequest();
            }

            _context.Entry(TbCongTrinhCoSoVatChat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCongTrinhCoSoVatChatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CanBo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbCongTrinhCoSoVatChat>> PostTbCongTrinhCoSoVatChat(TbCongTrinhCoSoVatChat TbCongTrinhCoSoVatChat)
        {
            _context.TbCongTrinhCoSoVatChats.Add(TbCongTrinhCoSoVatChat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbCongTrinhCoSoVatChatExists(TbCongTrinhCoSoVatChat.IdCongTrinhCoSoVatChat))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbCongTrinhCoSoVatChat", new { id = TbCongTrinhCoSoVatChat.IdCongTrinhCoSoVatChat }, TbCongTrinhCoSoVatChat);
        }

        // DELETE: api/CanBo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCongTrinhCoSoVatChat(int id)
        {
            var TbCongTrinhCoSoVatChat = await _context.TbCongTrinhCoSoVatChats.FindAsync(id);
            if (TbCongTrinhCoSoVatChat == null)
            {
                return NotFound();
            }

            _context.TbCongTrinhCoSoVatChats.Remove(TbCongTrinhCoSoVatChat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCongTrinhCoSoVatChatExists(int id)
        {
            return _context.TbCongTrinhCoSoVatChats.Any(e => e.IdCongTrinhCoSoVatChat == id);
        }
    }
}
