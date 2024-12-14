using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private Context _context;
        public HumanController(Context context) 
        {
            _context = context;
        }
        [HttpGet("nguoi")]
        public async Task<IEnumerable<human>> GetHuman()
        {
            List<human> humans = await _context.humans.ToListAsync();
            return humans.ToArray();
        }
        [HttpGet("nguoi/{id}")]
        public async Task<human> GetHuman(int id)
        {
            human _human = await _context.humans.FirstOrDefaultAsync(h => h.IdNguoi == id);
            return _human;
        }
    }
}
