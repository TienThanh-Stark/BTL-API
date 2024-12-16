using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;
using C500Hemis.API;
using C500Hemis.Models.DM;
using System.IO;
using OfficeOpenXml;

namespace C500Hemis.Controllers.CSGD
{
    public class DonViLienKetDaoTaoGiaoDucController : Controller
    {
        private readonly ApiServices ApiServices_;
       
        public DonViLienKetDaoTaoGiaoDucController(ApiServices services)
        {
            ApiServices_ = services;
        }

      

        private async Task<List<TbDonViLienKetDaoTaoGiaoDuc>> TbDonViLienKetDaoTaoGiaoDucs()
        {
            List<TbDonViLienKetDaoTaoGiaoDuc> tbDonViLienKetDaoTaoGiaoDucs = await ApiServices_.GetAll<TbDonViLienKetDaoTaoGiaoDuc>("/api/csgd/DonViLienKetDaoTaoGiaoDuc");
            List<TbCoSoGiaoDuc> TbCoSoGiaoDucs = await ApiServices_.GetAll<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc");
            List<DmLoaiLienKet> dmLoaiLienKets = await ApiServices_.GetAll<DmLoaiLienKet>("/api/dm/LoaiLienKet");
            tbDonViLienKetDaoTaoGiaoDucs.ForEach(item => {
                item.IdCoSoGiaoDucNavigation = TbCoSoGiaoDucs.FirstOrDefault(x => x.IdCoSoGiaoDuc == item.IdCoSoGiaoDuc);
                item.IdLoaiLienKetNavigation = dmLoaiLienKets.FirstOrDefault(x => x.IdLoaiLienKet == item.IdLoaiLienKet);
               
            });
            return tbDonViLienKetDaoTaoGiaoDucs;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbDonViLienKetDaoTaoGiaoDuc> getall = await TbDonViLienKetDaoTaoGiaoDucs();
                // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index
                return View(getall);
               
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // Lấy chi tiết 1 bản ghi dựa theo ID tương ứng đã truyền vào (IdChuongTrinhDaoTao)
        // Hiển thị bản ghi đó ở view Details
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm các dữ liệu theo Id tương ứng đã truyền vào view Details
                var tbDonViLienKetDaoTaoGiaoDucs = await TbDonViLienKetDaoTaoGiaoDucs();
                var tbDonViLienKetDaoTaoGiaoDuc = tbDonViLienKetDaoTaoGiaoDucs.FirstOrDefault(m => m.IdDonViLienKetDaoTaoGiaoDuc == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbDonViLienKetDaoTaoGiaoDuc == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CSGD thành công
                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: DonViLienKetDaoTaoGiaoDuc/Create
        // Hiển thị view Create để tạo một bản ghi CSGD
        // Truyền data từ các table khác hiển thị tại view Create (khóa ngoài)
        public async Task<IActionResult> Create()
        {
            try
            { 
                ViewData["IdCoSoGiaoDuc"] = new SelectList(await ApiServices_.GetAll<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc"), "IdCoSoGiaoDuc", "TenDonVi");
                ViewData["IdLoaiLienKet"] = new SelectList(await ApiServices_.GetAll<DmLoaiLienKet>("/api/dm/LoaiLienKet"), "IdLoaiLienKet", "LoaiLienKet");
                 return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: ChuongTrinhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // Thêm một CSGD mới vào Database nếu IdChuongTrinhDaoTao truyền vào không trùng với Id đã có trong Database
        // Trong trường hợp nhập trùng IdDonViLKDTGD sẽ bắt lỗi
        // Bắt lỗi ngoại lệ sao cho người nhập BẮT BUỘC phải nhập khác IdChuongTrinhDaoTao đã có
        [HttpPost]
        [ValidateAntiForgeryToken] // Một phương thức bảo mật thông qua Token được tạo tự động cho các Form khác nhau
        public async Task<IActionResult> Create([Bind("IdDonViLienKetDaoTaoGiaoDuc,IdCoSoGiaoDuc,DiaChi,DienThoai,IdLoaiLienKet")] TbDonViLienKetDaoTaoGiaoDuc tbDonViLienKetDaoTaoGiaoDuc)
        {
            try
            {
                // Nếu trùng ID.DVLKDTGD sẽ báo lỗi                
                if (await TbDonViLienKetDaoTaoGiaoDucExists(tbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc)) ModelState.AddModelError("IdDonViLienKetDaoTaoGiaoDuc", "Đã tồn tại Id này!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create< TbDonViLienKetDaoTaoGiaoDuc > ("/api/csgd/DonViLienKetDaoTaoGiaoDuc", tbDonViLienKetDaoTaoGiaoDuc);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCoSoGiaoDuc"] = new SelectList(await ApiServices_.GetAll<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc"), "IdCoSoGiaoDuc", "TenDonVi",tbDonViLienKetDaoTaoGiaoDuc.IdCoSoGiaoDuc);
                ViewData["IdLoaiLienKet"] = new SelectList(await ApiServices_.GetAll<DmLoaiLienKet>("/api/dm/LoaiLienKet"), "IdLoaiLienKet", "LoaiLienKet", tbDonViLienKetDaoTaoGiaoDuc.IdLoaiLienKet);
                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)    
            {
                return BadRequest();
            }

        }

        // GET: DonViLietKetDaoTaoGiaoDuc/Edit
        // Nếu không tìm thấy Id tương ứng sẽ báo lỗi NotFound
        // Phương thức này gần giống Create, nhưng nó nhập dữ liệu vào Id đã có trong API
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbDonViLienKetDaoTaoGiaoDuc = await ApiServices_.GetId<TbDonViLienKetDaoTaoGiaoDuc>("/api/csgd/DonViLienKetDaoTaoGiaoDuc", id ?? 0);
                if (tbDonViLienKetDaoTaoGiaoDuc == null)
                {
                    return NotFound();
                }
                ViewData["IdCoSoGiaoDuc"] = new SelectList(await ApiServices_.GetAll<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc"), "IdCoSoGiaoDuc", "TenDonVi" );
                ViewData["IdLoaiLienKet"] = new SelectList(await ApiServices_.GetAll<DmLoaiLienKet>("/api/dm/LoaiLienKet"), "IdLoaiLienKet", "LoaiLienKet");
                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: ChuongTrinhDaoTao/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // Lưu data mới (ghi đè) vào các trường Data đã có thuộc IdDVLKDTGDcần chỉnh sửa
        // Nó chỉ cập nhật khi ModelState hợp lệ
        // Nếu không hợp lệ sẽ báo lỗi, vì vậy cần có bắt lỗi.

        [HttpPost]
        [ValidateAntiForgeryToken] // Một phương thức bảo mật thông qua Token được tạo tự động cho các Form khác nhau
        public async Task<IActionResult> Edit (int id, [Bind("IdDonViLienKetDaoTaoGiaoDuc,IdCoSoGiaoDuc,DiaChi,DienThoai,IdLoaiLienKet")] TbDonViLienKetDaoTaoGiaoDuc tbDonViLienKetDaoTaoGiaoDuc)
        {
            try
            {
                if (id != tbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbDonViLienKetDaoTaoGiaoDuc>("/api/csgd/DonViLienKetDaoTaoGiaoDuc", id, tbDonViLienKetDaoTaoGiaoDuc);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbDonViLienKetDaoTaoGiaoDucExists(tbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc) == false)
                        {
                            return NotFound();  
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdCoSoGiaoDuc"] = new SelectList(await ApiServices_.GetAll<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc"), "IdCoSoGiaoDuc", "TenDonVi", tbDonViLienKetDaoTaoGiaoDuc.IdCoSoGiaoDuc);
                ViewData["IdLoaiLienKet"] = new SelectList(await ApiServices_.GetAll<DmLoaiLienKet>("/api/dm/LoaiLienKet"), "IdLoaiLienKet", "LoaiLienKet", tbDonViLienKetDaoTaoGiaoDuc.IdLoaiLienKet);
                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: ChuongTrinhDaoTao/Delete
        // Xóa một CTĐT khỏi Database
        // Lấy data CTĐT từ Database, hiển thị Data tại view Delete
        // Hàm này để hiển thị thông tin cho người dùng trước khi xóa
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var tbDonViLienKetDaoTaoGiaoDucs = await ApiServices_.GetAll<TbDonViLienKetDaoTaoGiaoDuc>("/api/csgd/DonViLienKetDaoTaoGiaoDuc");
                var tbDonViLienKetDaoTaoGiaoDuc = tbDonViLienKetDaoTaoGiaoDucs.FirstOrDefault(m => m.IdDonViLienKetDaoTaoGiaoDuc == id);
                if (tbDonViLienKetDaoTaoGiaoDuc == null)
                {
                    return NotFound();
                }

                return View(tbDonViLienKetDaoTaoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: ChuongTrinhDaoTao/Delete
        // Xóa CTĐT khỏi Database sau khi nhấn xác nhận 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // Lệnh xác nhận xóa hẳn một CTĐT
        {
            try
            {
                await ApiServices_.Delete<TbDonViLienKetDaoTaoGiaoDuc>("/api/csgd/DonViLienKetDaoTaoGiaoDuc", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
        // Phương thức xuất dữ liệu ra file Excel
        public async Task<IActionResult> ExportToExcel()
        {
            try
            {
                // Lấy danh sách dữ liệu từ API
                List<TbDonViLienKetDaoTaoGiaoDuc> data = await TbDonViLienKetDaoTaoGiaoDucs();

                using (var package = new ExcelPackage())
                {
                    // Tạo một worksheet mới
                    var worksheet = package.Workbook.Worksheets.Add("DonViLienKetDaoTaoGiaoDuc");

                    // Đặt tiêu đề cột
                    worksheet.Cells[1, 1].Value = "ID";
                    worksheet.Cells[1, 2].Value = "Cơ Sở Giáo Dục";
                    worksheet.Cells[1, 3].Value = "Địa Chỉ";
                    worksheet.Cells[1, 4].Value = "Điện Thoại";
                    worksheet.Cells[1, 5].Value = "Loại liên kết";

                    // Điền dữ liệu vào các hàng
                    for (int i = 0; i < data.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = data[i].IdDonViLienKetDaoTaoGiaoDuc;
                        worksheet.Cells[i + 2, 2].Value = data[i].IdCoSoGiaoDuc; // Lấy tên cơ sở giáo dục
                        worksheet.Cells[i + 2, 3].Value = data[i].DiaChi;
                        worksheet.Cells[i + 2, 4].Value = data[i].DienThoai;
                        worksheet.Cells[i + 2, 5].Value = data[i].IdLoaiLienKet; // Lấy tên loại liên kết
                    }


                    // Định dạng tự động cột
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Tạo byte array để trả về file
                    var fileContents = package.GetAsByteArray();

                    return File(
                        fileContents,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "DonViLienKetDaoTaoGiaoDuc.xlsx"
                    );
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                return BadRequest("Có lỗi xảy ra khi xuất file Excel.");
            }
        }

        //import dữ liệu


            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> ImportFromExcel(IFormFile formFile)
        {
            if (formFile == null || formFile.Length <= 0)
            {
                return BadRequest("File không hợp lệ!");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("File phải có định dạng .xlsx!");
            }

            try
            {
                var list = new List<TbDonViLienKetDaoTaoGiaoDuc>();

                using (var stream = new MemoryStream())
                {
                    // Đọc file Excel vào stream
                    await formFile.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        // Lấy worksheet đầu tiên
                        var worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        // Duyệt qua các hàng trong file Excel, bắt đầu từ hàng 2 (hàng 1 là tiêu đề)
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var tbDonViLienKetDaoTaoGiaoDuc = new TbDonViLienKetDaoTaoGiaoDuc
                            {
                                IdDonViLienKetDaoTaoGiaoDuc = Convert.ToInt32(worksheet.Cells[row, 1].Value?.ToString().Trim()),
                                IdCoSoGiaoDuc = string.IsNullOrWhiteSpace(worksheet.Cells[row, 2].Value?.ToString().Trim())
    ? (int?)null
    : Convert.ToInt32(worksheet.Cells[row, 2].Value?.ToString().Trim()),
                                DiaChi = worksheet.Cells[row, 3].Value?.ToString().Trim(),
                                DienThoai = worksheet.Cells[row, 4].Value?.ToString().Trim(),
                                IdLoaiLienKet = string.IsNullOrWhiteSpace(worksheet.Cells[row, 5].Value?.ToString().Trim())
    ? (int?)null
    : Convert.ToInt32(worksheet.Cells[row, 5].Value?.ToString().Trim())

                            };

                            // Thêm từng bản ghi vào danh sách
                            list.Add(tbDonViLienKetDaoTaoGiaoDuc);
                        }
                    }
                }

                // Lưu danh sách vào cơ sở dữ liệu thông qua API
                foreach (var item in list)
                {
                    if (!await TbDonViLienKetDaoTaoGiaoDucExists(item.IdDonViLienKetDaoTaoGiaoDuc))
                    {
                        await ApiServices_.Create<TbDonViLienKetDaoTaoGiaoDuc>("/api/csgd/DonViLienKetDaoTaoGiaoDuc", item);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest($"Có lỗi xảy ra khi nhập file Excel: {ex.Message}");
            }
        }

        //CHart
        [HttpGet]
        public async Task<IActionResult> ChartData()
        {
            try
            {
                var data = await TbDonViLienKetDaoTaoGiaoDucs();

                // Nhóm theo IdLoaiPhongBan và đếm số lượng
                var chartData = data.GroupBy(x => x.IdCoSoGiaoDucNavigation.TenDonVi) //đối tượng hiển thị
                    .Select(g => new
                    {
                        Label = g.Key,
                        Count = g.Count() // Đếm số lượng phòng ban cho mỗi loại
                    }).ToList();

                return Json(new
                {
                    labels = chartData.Select(x => x.Label).ToArray(),
                    values = chartData.Select(x => x.Count).ToArray() // Số lượng tương ứng
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private async Task<bool> TbDonViLienKetDaoTaoGiaoDucExists(int id)
        {
            var tbDonViLienKetDaoTaoGiaoDucs = await ApiServices_.GetAll<TbDonViLienKetDaoTaoGiaoDuc>("/api/csgd/DonViLienKetDaoTaoGiaoDuc");
            return tbDonViLienKetDaoTaoGiaoDucs.Any(e => e.IdDonViLienKetDaoTaoGiaoDuc == id);
        }

    }
}