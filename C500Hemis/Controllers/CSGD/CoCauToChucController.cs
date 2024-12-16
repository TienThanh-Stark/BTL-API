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
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using OfficeOpenXml;

namespace C500Hemis.Controllers.CSGD
{
    public class CoCauToChucController : Controller
    {
        private readonly ApiServices ApiServices_;

        public CoCauToChucController(ApiServices services)
        {
            ApiServices_ = services;
        }
        private async Task<List<TbCoCauToChuc>> TbCoCauToChucs()
        {
            List<TbCoCauToChuc> tbCoCauToChucs = await ApiServices_.GetAll<TbCoCauToChuc>("/api/csgd/CoCauToChuc");
            List<DmLoaiPhongBan> dmloaiPhongBans = await ApiServices_.GetAll<DmLoaiPhongBan>("/api/dm/LoaiPhongBan");
            List<DmTrangThaiCoSoGd> dmtrangThaiCoSoGds = await ApiServices_.GetAll<DmTrangThaiCoSoGd>("/api/dm/TrangThaiCoSoGd");
            tbCoCauToChucs.ForEach(item => {
                item.IdLoaiPhongBanNavigation = dmloaiPhongBans.FirstOrDefault(x => x.IdLoaiPhongBan == item.IdLoaiPhongBan);
                item.IdTrangThaiNavigation = dmtrangThaiCoSoGds.FirstOrDefault(x => x.IdTrangThaiCoSoGd == item.IdTrangThai);
            });
            return tbCoCauToChucs;
        }

        // GET: CoCauToChuc
        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbCoCauToChuc> getall = await TbCoCauToChucs();
                // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index
                return View(getall);
                // Bắt lỗi các trường hợp ngoại lệ
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: CoCauToChuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm các dữ liệu theo Id tương ứng đã truyền vào view Details
                var tbCoCauToChucs = await TbCoCauToChucs();
                var tbCoCauToChuc = tbCoCauToChucs.FirstOrDefault(m => m.IdCoCauToChuc == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbCoCauToChuc == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbCoCauToChuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: CoCauToChuc/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["IdLoaiPhongBan"] = new SelectList(await ApiServices_.GetAll<DmLoaiPhongBan>("/api/dm/LoaiPhongBan"), "IdLoaiPhongBan", "LoaiPhongBan");
                ViewData["IdTrangThai"] = new SelectList(await ApiServices_.GetAll<DmTrangThaiCoSoGd>("/api/dm/TrangThaiCoSoGd"), "IdTrangThaiCoSoGd", "TrangThaiCoSoGd");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: CoCauToChuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCoCauToChuc,MaPhongBanDonVi,IdLoaiPhongBan,MaPhongBanDonViCha,TenPhongBanDonVi,SoQuyetDinhThanhLap,NgayRaQuyetDinh,IdTrangThai")] TbCoCauToChuc tbCoCauToChuc)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbCoCauToChucExists(tbCoCauToChuc.IdCoCauToChuc)) ModelState.AddModelError("IdCoCauToChuc", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbCoCauToChuc>("/api/csgd/CoCauToChuc", tbCoCauToChuc);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdLoaiPhongBan"] = new SelectList(await ApiServices_.GetAll<DmLoaiPhongBan>("/api/dm/LoaiPhongBan"), "IdLoaiPhongBan", "LoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
                ViewData["IdTrangThai"] = new SelectList(await ApiServices_.GetAll<DmTrangThaiCoSoGd>("/api/dm/TrangThaiCoSoGd"), "IdTrangThaiCoSoGd", "TrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
                return View(tbCoCauToChuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: CoCauToChuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbCoCauToChuc = await ApiServices_.GetId<TbCoCauToChuc>("/api/csgd/CoCauToChuc", id ?? 0);
                if (tbCoCauToChuc == null)
                {
                    return NotFound();
                }
                ViewData["IdLoaiPhongBan"] = new SelectList(await ApiServices_.GetAll<DmLoaiPhongBan>("/api/dm/LoaiPhongBan"), "IdLoaiPhongBan", "LoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
                ViewData["IdTrangThai"] = new SelectList(await ApiServices_.GetAll<DmTrangThaiCoSoGd>("/api/dm/TrangThaiCoSoGd"), "IdTrangThaiCoSoGd", "TrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
                return View(tbCoCauToChuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        // POST: CoCauToChuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCoCauToChuc,MaPhongBanDonVi,IdLoaiPhongBan,MaPhongBanDonViCha,TenPhongBanDonVi,SoQuyetDinhThanhLap,NgayRaQuyetDinh,IdTrangThai")] TbCoCauToChuc tbCoCauToChuc)
        {
            try
            {
                if (id != tbCoCauToChuc.IdCoCauToChuc)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbCoCauToChuc>("/api/csgd/CoCauToChuc", id, tbCoCauToChuc);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbCoCauToChucExists(tbCoCauToChuc.IdCoCauToChuc) == false)
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
                ViewData["IdLoaiPhongBan"] = new SelectList(await ApiServices_.GetAll<DmLoaiPhongBan>("/api/dm/LoaiPhongBan"), "IdLoaiPhongBan", "LoaiPhongBan", tbCoCauToChuc.IdLoaiPhongBan);
                ViewData["IdTrangThai"] = new SelectList(await ApiServices_.GetAll<DmTrangThaiCoSoGd>("/api/dm/TrangThaiCoSoGd"), "IdTrangThaiCoSoGd", "TrangThaiCoSoGd", tbCoCauToChuc.IdTrangThai);
                return View(tbCoCauToChuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        // GET: CoCauToChuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var tbCoCauToChucs = await ApiServices_.GetAll<TbCoCauToChuc>("/api/csgd/CoCauToChuc");
                var tbCoCauToChuc = tbCoCauToChucs.FirstOrDefault(m => m.IdCoCauToChuc == id);
                if (tbCoCauToChuc == null)
                {
                    return NotFound();
                }

                return View(tbCoCauToChuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: CoCauToChuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await ApiServices_.Delete<TbCoCauToChuc>("/api/csgd/CoCauToChuc", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> ExportToExcel()
        {
            // Lấy dữ liệu từ API hoặc database
            List<TbCoCauToChuc> data = await TbCoCauToChucs();

            // Tạo một file Excel với EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách cơ cấu tổ chức");

                // Hợp nhất và đặt tiêu đề lớn
                worksheet.Cells[1, 1, 1, 8].Merge = true;
                worksheet.Cells[1, 1].Value = "Báo cáo danh sách cơ cấu tổ chức";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Tiêu đề bảng
                worksheet.Cells[2, 1].Value = "ID";
                worksheet.Cells[2, 2].Value = "Mã Phòng Đơn Vị";
                worksheet.Cells[2, 3].Value = "Mã Phòng Đơn Vị Cha";
                worksheet.Cells[2, 4].Value = "Tên Phòng Ban Đơn Vị";
                worksheet.Cells[2, 5].Value = "Số Quyết Định Thành Lập";
                worksheet.Cells[2, 6].Value = "Ngày Ra Quyết Định";
                worksheet.Cells[2, 7].Value = "Loại Phòng Ban";
                worksheet.Cells[2, 8].Value = "Trạng Thái";

                // Định dạng tiêu đề
                using (var range = worksheet.Cells[2, 1, 2, 8])
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
                    worksheet.Cells[row, 1].Value = item.IdCoCauToChuc; // ID
                    worksheet.Cells[row, 2].Value = item.MaPhongBanDonVi; // Mã Phòng Đơn Vị
                    worksheet.Cells[row, 3].Value = item.MaPhongBanDonViCha; // Mã Phòng Đơn Vị Cha
                    worksheet.Cells[row, 4].Value = item.TenPhongBanDonVi; // Tên Phòng Ban Đơn Vị
                    worksheet.Cells[row, 5].Value = item.SoQuyetDinhThanhLap; // Số Quyết Định Thành Lập
                    worksheet.Cells[row, 6].Value = item.NgayRaQuyetDinh; // Ngày Ra Quyết Định
                    worksheet.Cells[row, 7].Value = item.IdLoaiPhongBanNavigation?.LoaiPhongBan; // Loại Phòng Ban
                    worksheet.Cells[row, 8].Value = item.IdTrangThaiNavigation?.TrangThaiCoSoGd; // Trạng Thái
                    row++;
                }

                // Thêm viền cho toàn bộ bảng
                worksheet.Cells[2, 1, row - 1, 8].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 8].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 8].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 8].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                worksheet.Cells.AutoFitColumns();

                var stream = new System.IO.MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = $"DanhSachCoCauToChuc_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
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

                        var tbCoCauToChucs = new List<TbCoCauToChuc>();

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var loaiPhongBanList = await ApiServices_.GetAll<DmLoaiPhongBan>("/api/dm/LoaiPhongBan");
                            var tenLoaiPhongBan = worksheet.Cells[row, 7].Text.Trim(); // Lấy tên từ Excel
                            var loaiPhongBan = loaiPhongBanList.FirstOrDefault(lpb => lpb.LoaiPhongBan == tenLoaiPhongBan);

                            var trangThaiList = await ApiServices_.GetAll<DmTrangThaiCoSoGd>("/api/dm/TrangThaiCoSoGd");
                            var tenTrangThai = worksheet.Cells[row, 8].Text.Trim(); // Lấy tên từ Excel
                            var trangThaiCoSoGd = trangThaiList.FirstOrDefault(lpb => lpb.TrangThaiCoSoGd == tenTrangThai);

                            var item = new TbCoCauToChuc
                            {
                                IdCoCauToChuc = int.Parse(worksheet.Cells[row, 1].Text),
                                MaPhongBanDonVi = worksheet.Cells[row, 2].Text,
                                MaPhongBanDonViCha = worksheet.Cells[row, 3].Text,
                                TenPhongBanDonVi = worksheet.Cells[row, 4].Text,
                                SoQuyetDinhThanhLap = worksheet.Cells[row, 5].Text,
                                NgayRaQuyetDinh = DateTime.TryParseExact(worksheet.Cells[row, 6].Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate) ? DateOnly.FromDateTime(parsedDate) : null,
                                IdLoaiPhongBan = loaiPhongBan?.IdLoaiPhongBan,
                                IdTrangThai = trangThaiCoSoGd?.IdTrangThaiCoSoGd
                            };

                            tbCoCauToChucs.Add(item);
                        }



                        // Gửi dữ liệu tới API để lưu vào database
                        foreach (var tbCoCauToChuc in tbCoCauToChucs)
                        {
                            await ApiServices_.Create<TbCoCauToChuc>("/api/csgd/CoCauToChuc", tbCoCauToChuc);
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

        [HttpGet]
        public async Task<IActionResult> ChartData(string dataType)
        {
            try
            {
                var data = await TbCoCauToChucs();

                IEnumerable<dynamic> chartData;

                if (dataType == "LoaiPhongBan")
                {
                    // Nhóm theo IdLoaiPhongBan và đếm số lượng
                    chartData = data.GroupBy(x => x.IdLoaiPhongBanNavigation.LoaiPhongBan)
                        .Select(g => new
                        {
                            Label = g.Key,
                            Count = g.Count()
                        }).ToList();
                }
                else if (dataType == "TrangThai")
                {
                    // Nhóm theo IdTrangThai và đếm số lượng
                    chartData = data.GroupBy(x => x.IdTrangThaiNavigation.TrangThaiCoSoGd)
                        .Select(g => new
                        {
                            Label = g.Key,
                            Count = g.Count()
                        }).ToList();
                }
                else
                {
                    return BadRequest("Loại dữ liệu không hợp lệ.");
                }

                return Json(new
                {
                    labels = chartData.Select(x => x.Label).ToArray(),
                    values = chartData.Select(x => x.Count).ToArray()
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        private async Task<bool> TbCoCauToChucExists(int id)
        {
            var tbCoCauToChucs = await ApiServices_.GetAll<TbCoCauToChuc>("/api/csgd/CoCauToChuc");
            return tbCoCauToChucs.Any(e => e.IdCoCauToChuc == id);
        }
    }
}