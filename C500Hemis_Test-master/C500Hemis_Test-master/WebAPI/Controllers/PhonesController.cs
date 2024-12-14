using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebAPI.API;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        [HttpGet]
        public async Task<string> send()
        {
            /** Đầu tiên bạn tạo một instance của class SpeedSMSAPI với tham số là api ccess token của bạn.
            */
            SpeedSMSAPI api  = new SpeedSMSAPI("AOe17l_7j0aThJeyK5VRqU2AbThJtXE1");
            /**
            * Để lấy thông tin về tài khoản như: email, số dư tài khoản bạn sử dụng hàm getUserInfo()
            */
            String userInfo = api.getUserInfo();
            /* * Hàm getUserInfo() sẽ trả về một json string như sau:
            * /
            {"email": "test@speedsms.vn", "balance": 100000.0, "currency": "VND"}

            /** Để gửi SMS bạn sử dụng hàm sendSMS như sau:
            */
            String[] phones = new String[] { "0394196390" };
            String content = "test sms";
            int type = 2;
            /**
            sms_type có các giá trị như sau:
            2: tin nhắn gửi bằng đầu số ngẫu nhiên
            3: tin nhắn gửi bằng brandname
            4: tin nhắn gửi bằng brandname mặc định (Verify hoặc Notify)
            5: tin nhắn gửi bằng app android
            */
            String sender = "";
            /**
            brandname là tên thương hiệu hoặc số điện thoại đã đăng ký với SpeedSMS hoặc android deviceId của bạn
            */

            String response = api.sendSMS(phones, content, type, sender);
            /**hàm sendSMS sẽ trả về một json string như sau:*/
            /*
            {
            "status": "success", "code": "00", 
            "data": {
                "tranId": 123456, "totalSMS": 1,     
                "totalPrice": 250, "invalidPhone": [] 
                }
            }
            */
            // Trong trường hợp gửi sms bị lỗi, hàm sendSMS sẽ trả về json string như sau:
            /*{
            "status": "error", "code": "error code", "message" : "error description",
            "invalidPhone": ["danh sách sdt lỗi"]
            }*/
            return response;
        }
    }
}
