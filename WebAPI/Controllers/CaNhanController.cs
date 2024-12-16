using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaNhanController : ControllerBase
    {
        List<Thongtin> thongtins = new List<Thongtin>()
        {
            new Thongtin(){cccd = 1, gioitinh = "nam", namsinh = 1999, name = "PXL"},
            new Thongtin(){cccd = 2, gioitinh = "nam", namsinh = 1999, name = "CTP"},
            new Thongtin(){cccd = 3, gioitinh = "nam", namsinh = 1999, name = "NHK"},
            new Thongtin(){cccd = 4, gioitinh = "nam", namsinh = 1999, name = "CKH"},
        };
        IEnumerable<string> ds = new List<string>() { "Hà Nội", "Nghệ An", "Thanh Hóa" };
        [HttpGet("Hoten")]
        public string get()
        {
            return "Họ tên : CTP";
        }
        [HttpGet("Thongtin")]
        public Thongtin thongtin(int id)
        {
            Thongtin thongtin = thongtins.FirstOrDefault(t => t.cccd == id);
            return thongtin;
        }
        [HttpGet("Noituyensinh")]
        public IEnumerable<string> Noits()
        {
            return ds.ToArray();
        }
    }
}
