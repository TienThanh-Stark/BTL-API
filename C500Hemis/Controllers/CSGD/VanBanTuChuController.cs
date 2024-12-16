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
using OfficeOpenXml;

namespace C500Hemis.Controllers.CSGD
{
    public class VanBanTuChuController : Controller
    {
        private readonly ApiServices ApiServices_;

        public VanBanTuChuController(ApiServices services)
        {
            ApiServices_ = services;
        }

        private async Task<List<TbVanBanTuChu>> TbVanBanTuChus()
        {
            List<TbVanBanTuChu> tbVanBanTuChus = await ApiServices_.GetAll<TbVanBanTuChu>("/api/csgd/VanBanTuChu");
            return tbVanBanTuChus;
        }

        // GET: VanBanTuChu
        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbVanBanTuChu> getall = await TbVanBanTuChus();
                // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index
                return View(getall);
                // Bắt lỗi các trường hợp ngoại lệ
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: VanBanTuChu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm các dữ liệu theo Id tương ứng đã truyền vào view Details
                var tbVanBanTuChus = await TbVanBanTuChus();
                var tbVanBanTuChu = tbVanBanTuChus.FirstOrDefault(m => m.IdVanBanTuChu == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbVanBanTuChu == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbVanBanTuChu);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: VanBanTuChu/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: VanBanTuChu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVanBanTuChu,LoaiVanBan,NoiDungVanBan,QuyetDinhBanHanh,CoQuanQuyetDinhBanHanh")] TbVanBanTuChu tbVanBanTuChu)
        {
            // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
            if (await TbVanBanTuChuExists(tbVanBanTuChu.IdVanBanTuChu)) ModelState.AddModelError("IdVanBanTuChu", "ID này đã tồn tại!");
            if (ModelState.IsValid)
            {
                await ApiServices_.Create<TbVanBanTuChu>("/api/csgd/VanBanTuChu", tbVanBanTuChu);
                return RedirectToAction(nameof(Index));
            }
            return View(tbVanBanTuChu);
        }

        // GET: VanBanTuChu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbVanBanTuChu = await ApiServices_.GetId<TbVanBanTuChu>("/api/csgd/VanBanTuChu", id ?? 0);
            if (tbVanBanTuChu == null)
            {
                return NotFound();
            }
            return View(tbVanBanTuChu);
        }

        // POST: VanBanTuChu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVanBanTuChu,LoaiVanBan,NoiDungVanBan,QuyetDinhBanHanh,CoQuanQuyetDinhBanHanh")] TbVanBanTuChu tbVanBanTuChu)
        {
            if (id != tbVanBanTuChu.IdVanBanTuChu)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await ApiServices_.Update<TbVanBanTuChu>("/api/csgd/VanBanTuChu", id, tbVanBanTuChu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await TbVanBanTuChuExists(tbVanBanTuChu.IdVanBanTuChu) == false)
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
            return View(tbVanBanTuChu);
        }

        // GET: VanBanTuChu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbVanBanTuChus = await ApiServices_.GetAll<TbVanBanTuChu>("/api/csgd/VanBanTuChu");
            var tbVanBanTuChu = tbVanBanTuChus.FirstOrDefault(m => m.IdVanBanTuChu == id);
            if (tbVanBanTuChu == null)
            {
                return NotFound();
            }

            return View(tbVanBanTuChu);
        }

        // POST: VanBanTuChu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ApiServices_.Delete<TbVanBanTuChu>("/api/csgd/VanBanTuChu", id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ExportToExcel()
        {
            // Lấy dữ liệu từ API hoặc database
            List<TbVanBanTuChu> data = await TbVanBanTuChus();

            // Tạo một file Excel với EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách văn bản từ chữ");

                // Hợp nhất và đặt tiêu đề lớn
                worksheet.Cells[1, 1, 1, 5].Merge = true;
                worksheet.Cells[1, 1].Value = "Báo cáo danh sách Văn Bản Từ Chữ";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Tiêu đề bảng
                worksheet.Cells[2, 1].Value = "ID";
                worksheet.Cells[2, 2].Value = "Loại Văn Bản";
                worksheet.Cells[2, 3].Value = "Nội Dung Văn Bản";
                worksheet.Cells[2, 4].Value = "Quyết Định Ban Hành";
                worksheet.Cells[2, 5].Value = "Cơ Quan Quyết Định Ban Hành";

                // Định dạng tiêu đề
                using (var range = worksheet.Cells[2, 1, 2, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
                }
                // Thêm dữ liệu vào bảng
                int row = 3;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.IdVanBanTuChu;
                    worksheet.Cells[row, 2].Value = item.LoaiVanBan;
                    worksheet.Cells[row, 3].Value = item.NoiDungVanBan;
                    worksheet.Cells[row, 4].Value = item.QuyetDinhBanHanh;
                    worksheet.Cells[row, 5].Value = item.CoQuanQuyetDinhBanHanh;
                    row++;
                }

                // Thêm viền cho toàn bộ bảng
                worksheet.Cells[2, 1, row - 1, 5].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 5].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 5].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 5].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                worksheet.Cells.AutoFitColumns();

                var stream = new System.IO.MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = $"DanhSachVanBanTuChu_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }

        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(IFormFile file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (file == null || file.Length == 0)
            {
                return BadRequest("File không hợp lệ.");
            }

            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);

                    // Sử dụng EPPlus để đọc file Excel
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                        int rowCount = worksheet.Dimension.Rows; // Số lượng dòng
                        int colCount = worksheet.Dimension.Columns; // Số lượng cột

                        var tbVanBanTuChus = new List<TbVanBanTuChu>();

                        for (int row = 2; row <= rowCount; row++) // Giả sử dòng 1 là tiêu đề
                        {
                            var item = new TbVanBanTuChu
                            {
                                IdVanBanTuChu = int.Parse(worksheet.Cells[row, 1].Text),
                                LoaiVanBan = worksheet.Cells[row, 2].Text,
                                NoiDungVanBan = worksheet.Cells[row, 3].Text,
                                QuyetDinhBanHanh = worksheet.Cells[row, 4].Text,
                                CoQuanQuyetDinhBanHanh = worksheet.Cells[row, 5].Text,
                            };

                            tbVanBanTuChus.Add(item);
                        }


                        // Gửi dữ liệu tới API để lưu vào database
                        foreach (var tbVanBanTuChu in tbVanBanTuChus)
                        {
                            await ApiServices_.Create<TbVanBanTuChu>("/api/csgd/VanBanTuChu", tbVanBanTuChu);
                        }

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Đã xảy ra lỗi khi xử lý file.");
            }
        }

        // GET: CoCauToChuc/ChartData
        [HttpGet]
        public async Task<IActionResult> ChartData()
        {
            try
            {
                var data = await TbVanBanTuChus();

                // Nhóm theo IdLoaiPhongBan và đếm số lượng
                var chartData = data.GroupBy(x => x.LoaiVanBan)
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
        private async Task<bool> TbVanBanTuChuExists(int id)
        {
            var tbVanBanTuChus = await ApiServices_.GetAll<TbVanBanTuChu>("/api/csgd/VanBanTuChu");
            return tbVanBanTuChus.Any(e => e.IdVanBanTuChu == id);
        }
    }
}
