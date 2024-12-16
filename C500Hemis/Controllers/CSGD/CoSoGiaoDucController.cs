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
    public class CoSoGiaoDucController : Controller
    {
        private readonly ApiServices ApiServices_;

        public CoSoGiaoDucController(ApiServices services)
        {
            ApiServices_ = services;
        }
        private async Task<List<TbCoSoGiaoDuc>> TbCoSoGiaoDucs()
        {
            List<TbCoSoGiaoDuc> tbCoSoGiaoDucs = await ApiServices_.GetAll<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc");
            List<DmTuyChon> dmtuyChons = await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon");
            List<DmCoQuanChuQuan> dmcoQuanChuQuans = await ApiServices_.GetAll<DmCoQuanChuQuan>("/api/dm/CoQuanChuQuan");
            List<DmHinhThucThanhLap> dmhinhThucThanhLaps = await ApiServices_.GetAll<DmHinhThucThanhLap>("/api/dm/HinhThucThanhLap");
            List<DmHuyen> dmhuyens = await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen");
            List<DmLoaiHinhCoSoDaoTao> dmloaiHinhCoSoDaoTaos = await ApiServices_.GetAll<DmLoaiHinhCoSoDaoTao>("/api/dm/LoaiHinhCoSoDaoTao");
            List<DmLoaiHinhTruong> dmloaiHinhTruongs = await ApiServices_.GetAll<DmLoaiHinhTruong>("/api/dm/LoaiHinhTruong");
            List<DmPhanLoaiCoSo> dmphanLoaiCoSos = await ApiServices_.GetAll<DmPhanLoaiCoSo>("/api/dm/PhanLoaiCoSo");
            List<DmTinh> dmtinhs = await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh");
            List<DmXa> dmxas = await ApiServices_.GetAll<DmXa>("/api/dm/Xa");
            tbCoSoGiaoDucs.ForEach(item => {
                item.HoatDongKhongLoiNhuanNavigation = dmtuyChons.FirstOrDefault(x => x.IdTuyChon == item.HoatDongKhongLoiNhuan);
                item.IdCoQuanChuQuanNavigation = dmcoQuanChuQuans.FirstOrDefault(x => x.IdCoQuanChuQuan == item.IdCoQuanChuQuan);
                item.IdHinhThucThanhLapNavigation = dmhinhThucThanhLaps.FirstOrDefault(x => x.IdHinhThucThanhLap == item.IdHinhThucThanhLap);
                item.IdHuyenNavigation = dmhuyens.FirstOrDefault(x => x.IdHuyen == item.IdHuyen);
                item.IdLoaiHinhCoSoDaoTaoNavigation = dmloaiHinhCoSoDaoTaos.FirstOrDefault(x => x.IdLoaiHinhCoSoDaoTao == item.IdLoaiHinhCoSoDaoTao);
                item.IdLoaiHinhTruongNavigation = dmloaiHinhTruongs.FirstOrDefault(x => x.IdLoaiHinhTruong == item.IdLoaiHinhTruong);
                item.IdPhanLoaiCoSoNavigation = dmphanLoaiCoSos.FirstOrDefault(x => x.IdPhanLoaiCoSo == item.IdPhanLoaiCoSo);
                item.IdTinhNavigation = dmtinhs.FirstOrDefault(x => x.IdTinh == item.IdTinh);
                item.IdXaNavigation = dmxas.FirstOrDefault(x => x.IdXa == item.IdXa);
                item.TuChuGiaoDucQpanNavigation = dmtuyChons.FirstOrDefault(x => x.IdTuyChon == item.TuChuGiaoDucQpan);
            });
            return tbCoSoGiaoDucs;
        }

        // GET: CoSoGiaoDuc
        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbCoSoGiaoDuc> getall = await TbCoSoGiaoDucs();
                // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index
                return View(getall);
                // Bắt lỗi các trường hợp ngoại lệ
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: CoSoGiaoDuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                // Tìm các dữ liệu theo Id tương ứng đã truyền vào view Details
                var tbCoSoGiaoDucs = await TbCoSoGiaoDucs();
                var tbCoSoGiaoDuc = tbCoSoGiaoDucs.FirstOrDefault(m => m.IdCoSoGiaoDuc == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbCoSoGiaoDuc == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbCoSoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: CoSoGiaoDuc/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["HoatDongKhongLoiNhuan"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon");
                ViewData["IdCoQuanChuQuan"] = new SelectList(await ApiServices_.GetAll<DmCoQuanChuQuan>("/api/dm/CoQuanChuQuan"), "IdCoQuanChuQuan", "CoQuanChuQuan");
                ViewData["IdHinhThucThanhLap"] = new SelectList(await ApiServices_.GetAll<DmHinhThucThanhLap>("/api/dm/HinhThucThanhLap"), "IdHinhThucThanhLap", "HinhThucThanhLap");
                ViewData["IdHuyen"] = new SelectList(await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen"), "IdHuyen", "TenHuyen");
                ViewData["IdLoaiHinhCoSoDaoTao"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhCoSoDaoTao>("/api/dm/LoaiHinhCoSoDaoTao"), "IdLoaiHinhCoSoDaoTao", "LoaiHinhCoSoDaoTao");
                ViewData["IdLoaiHinhTruong"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhTruong>("/api/dm/LoaiHinhTruong"), "IdLoaiHinhTruong", "LoaiHinhTruong");
                ViewData["IdPhanLoaiCoSo"] = new SelectList(await ApiServices_.GetAll<DmPhanLoaiCoSo>("/api/dm/PhanLoaiCoSo"), "IdPhanLoaiCoSo", "PhanLoaiCoSo");
                ViewData["IdTinh"] = new SelectList(await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh"), "IdTinh", "TenTinh");
                ViewData["IdXa"] = new SelectList(await ApiServices_.GetAll<DmXa>("/api/dm/Xa"), "IdXa", "TenXa");
                ViewData["TuChuGiaoDucQpan"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon");
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: CoSoGiaoDuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCoSoGiaoDuc,MaDonVi,TenDonVi,TenTiengAnh,IdHinhThucThanhLap,IdLoaiHinhTruong,SoQuyetDinhChuyenDoiLoaiHinh,NgayKyQuyetDinhChuyenDoiLoaiHinh,TenDaiHocTrucThuoc,SoDienThoai,Fax,Email,DiaChiWebsite,IdCoQuanChuQuan,SoQuyetDinhThanhLap,NgayKyQuyetDinhThanhLap,DiaChi,IdTinh,IdHuyen,IdXa,HoatDongKhongLoiNhuan,SoQuyetDinhCapPhepHoatDong,NgayDuocCapPhepHoatDong,IdLoaiHinhCoSoDaoTao,SoGiaoVienGdtc,IdPhanLoaiCoSo,TuChuGiaoDucQpan,SoQuyetDinhGiaoTuChu,DaoTaoSvgdqpan1nam,SoQuyetDinhBanHanhQuyCheTaiChinh,NgayKyQuyetDinhBanHanhQuyCheTaiChinh")] TbCoSoGiaoDuc tbCoSoGiaoDuc)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbCoSoGiaoDucExists(tbCoSoGiaoDuc.IdCoSoGiaoDuc))
                {
                    ModelState.AddModelError("IdCoSoGiaoDuc", "ID này đã tồn tại!");
                }
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc", tbCoSoGiaoDuc);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["HoatDongKhongLoiNhuan"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon", tbCoSoGiaoDuc.HoatDongKhongLoiNhuan);
                ViewData["IdCoQuanChuQuan"] = new SelectList(await ApiServices_.GetAll<DmCoQuanChuQuan>("/api/dm/CoQuanChuQuan"), "IdCoQuanChuQuan", "CoQuanChuQuan", tbCoSoGiaoDuc.IdCoQuanChuQuan);
                ViewData["IdHinhThucThanhLap"] = new SelectList(await ApiServices_.GetAll<DmHinhThucThanhLap>("/api/dm/HinhThucThanhLap"), "IdHinhThucThanhLap", "HinhThucThanhLap", tbCoSoGiaoDuc.IdHinhThucThanhLap);
                ViewData["IdHuyen"] = new SelectList(await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen"), "IdHuyen", "TenHuyen", tbCoSoGiaoDuc.IdHuyen);
                ViewData["IdLoaiHinhCoSoDaoTao"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhCoSoDaoTao>("/api/dm/LoaiHinhCoSoDaoTao"), "IdLoaiHinhCoSoDaoTao", "LoaiHinhCoSoDaoTao", tbCoSoGiaoDuc.IdLoaiHinhCoSoDaoTao);
                ViewData["IdLoaiHinhTruong"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhTruong>("/api/dm/LoaiHinhTruong"), "IdLoaiHinhTruong", "LoaiHinhTruong", tbCoSoGiaoDuc.IdLoaiHinhTruong);
                ViewData["IdPhanLoaiCoSo"] = new SelectList(await ApiServices_.GetAll<DmPhanLoaiCoSo>("/api/dm/PhanLoaiCoSo"), "IdPhanLoaiCoSo", "PhanLoaiCoSo", tbCoSoGiaoDuc.IdPhanLoaiCoSo);
                ViewData["IdTinh"] = new SelectList(await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh"), "IdTinh", "TenTinh", tbCoSoGiaoDuc.IdTinh);
                ViewData["IdXa"] = new SelectList(await ApiServices_.GetAll<DmXa>("/api/dm/Xa"), "IdXa", "TenXa", tbCoSoGiaoDuc.IdXa);
                ViewData["TuChuGiaoDucQpan"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon", tbCoSoGiaoDuc.TuChuGiaoDucQpan);
                return View(tbCoSoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: CoSoGiaoDuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbCoSoGiaoDuc = await ApiServices_.GetId<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc", id ?? 0);
                if (tbCoSoGiaoDuc == null)
                {
                    return NotFound();
                }
                ViewData["HoatDongKhongLoiNhuan"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon", tbCoSoGiaoDuc.HoatDongKhongLoiNhuan);
                ViewData["IdCoQuanChuQuan"] = new SelectList(await ApiServices_.GetAll<DmCoQuanChuQuan>("/api/dm/CoQuanChuQuan"), "IdCoQuanChuQuan", "CoQuanChuQuan", tbCoSoGiaoDuc.IdCoQuanChuQuan);
                ViewData["IdHinhThucThanhLap"] = new SelectList(await ApiServices_.GetAll<DmHinhThucThanhLap>("/api/dm/HinhThucThanhLap"), "IdHinhThucThanhLap", "HinhThucThanhLap", tbCoSoGiaoDuc.IdHinhThucThanhLap);
                ViewData["IdHuyen"] = new SelectList(await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen"), "IdHuyen", "TenHuyen", tbCoSoGiaoDuc.IdHuyen);
                ViewData["IdLoaiHinhCoSoDaoTao"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhCoSoDaoTao>("/api/dm/LoaiHinhCoSoDaoTao"), "IdLoaiHinhCoSoDaoTao", "LoaiHinhCoSoDaoTao", tbCoSoGiaoDuc.IdLoaiHinhCoSoDaoTao);
                ViewData["IdLoaiHinhTruong"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhTruong>("/api/dm/LoaiHinhTruong"), "IdLoaiHinhTruong", "LoaiHinhTruong", tbCoSoGiaoDuc.IdLoaiHinhTruong);
                ViewData["IdPhanLoaiCoSo"] = new SelectList(await ApiServices_.GetAll<DmPhanLoaiCoSo>("/api/dm/PhanLoaiCoSo"), "IdPhanLoaiCoSo", "PhanLoaiCoSo", tbCoSoGiaoDuc.IdPhanLoaiCoSo);
                ViewData["IdTinh"] = new SelectList(await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh"), "IdTinh", "TenTinh", tbCoSoGiaoDuc.IdTinh);
                ViewData["IdXa"] = new SelectList(await ApiServices_.GetAll<DmXa>("/api/dm/Xa"), "IdXa", "TenXa", tbCoSoGiaoDuc.IdXa);
                ViewData["TuChuGiaoDucQpan"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon", tbCoSoGiaoDuc.TuChuGiaoDucQpan);
                return View(tbCoSoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: CoSoGiaoDuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCoSoGiaoDuc,MaDonVi,TenDonVi,TenTiengAnh,IdHinhThucThanhLap,IdLoaiHinhTruong,SoQuyetDinhChuyenDoiLoaiHinh,NgayKyQuyetDinhChuyenDoiLoaiHinh,TenDaiHocTrucThuoc,SoDienThoai,Fax,Email,DiaChiWebsite,IdCoQuanChuQuan,SoQuyetDinhThanhLap,NgayKyQuyetDinhThanhLap,DiaChi,IdTinh,IdHuyen,IdXa,HoatDongKhongLoiNhuan,SoQuyetDinhCapPhepHoatDong,NgayDuocCapPhepHoatDong,IdLoaiHinhCoSoDaoTao,SoGiaoVienGdtc,IdPhanLoaiCoSo,TuChuGiaoDucQpan,SoQuyetDinhGiaoTuChu,DaoTaoSvgdqpan1nam,SoQuyetDinhBanHanhQuyCheTaiChinh,NgayKyQuyetDinhBanHanhQuyCheTaiChinh")] TbCoSoGiaoDuc tbCoSoGiaoDuc)
        {
            try
            {
                if (id != tbCoSoGiaoDuc.IdCoSoGiaoDuc)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc", id, tbCoSoGiaoDuc);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbCoSoGiaoDucExists(tbCoSoGiaoDuc.IdCoSoGiaoDuc) == false)
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
                ViewData["HoatDongKhongLoiNhuan"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "idTuyChon", "tuyChon", tbCoSoGiaoDuc.HoatDongKhongLoiNhuan);
                ViewData["IdCoQuanChuQuan"] = new SelectList(await ApiServices_.GetAll<DmCoQuanChuQuan>("/api/dm/CoQuanChuQuan"), "IdCoQuanChuQuan", "CoQuanChuQuan", tbCoSoGiaoDuc.IdCoQuanChuQuan);
                ViewData["IdHinhThucThanhLap"] = new SelectList(await ApiServices_.GetAll<DmHinhThucThanhLap>("/api/dm/HinhThucThanhLap"), "IdHinhThucThanhLap", "HinhThucThanhLap", tbCoSoGiaoDuc.IdHinhThucThanhLap);
                ViewData["IdHuyen"] = new SelectList(await ApiServices_.GetAll<DmHuyen>("/api/dm/Huyen"), "IdHuyen", "TenHuyen", tbCoSoGiaoDuc.IdHuyen);
                ViewData["IdLoaiHinhCoSoDaoTao"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhCoSoDaoTao>("/api/dm/LoaiHinhCoSoDaoTao"), "IdLoaiHinhCoSoDaoTao", "LoaiHinhCoSoDaoTao", tbCoSoGiaoDuc.IdLoaiHinhCoSoDaoTao);
                ViewData["IdLoaiHinhTruong"] = new SelectList(await ApiServices_.GetAll<DmLoaiHinhTruong>("/api/dm/LoaiHinhTruong"), "IdLoaiHinhTruong", "LoaiHinhTruong", tbCoSoGiaoDuc.IdLoaiHinhTruong);
                ViewData["IdPhanLoaiCoSo"] = new SelectList(await ApiServices_.GetAll<DmPhanLoaiCoSo>("/api/dm/PhanLoaiCoSo"), "IdPhanLoaiCoSo", "PhanLoaiCoSo", tbCoSoGiaoDuc.IdPhanLoaiCoSo);
                ViewData["IdTinh"] = new SelectList(await ApiServices_.GetAll<DmTinh>("/api/dm/Tinh"), "IdTinh", "TenTinh", tbCoSoGiaoDuc.IdTinh);
                ViewData["IdXa"] = new SelectList(await ApiServices_.GetAll<DmXa>("/api/dm/Xa"), "IdXa", "TenXa", tbCoSoGiaoDuc.IdXa);
                ViewData["TuChuGiaoDucQpan"] = new SelectList(await ApiServices_.GetAll<DmTuyChon>("/api/dm/TuyChon"), "IdTuyChon", "TuyChon", tbCoSoGiaoDuc.TuChuGiaoDucQpan);
                return View(tbCoSoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET: CoSoGiaoDuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var tbCoSoGiaoDucs = await ApiServices_.GetAll<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc");
                var tbCoSoGiaoDuc = tbCoSoGiaoDucs.FirstOrDefault(m => m.IdCoSoGiaoDuc == id);
                if (tbCoSoGiaoDuc == null)
                {
                    return NotFound();
                }

                return View(tbCoSoGiaoDuc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST: CoSoGiaoDuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await ApiServices_.Delete<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc", id);
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
            List<TbCoSoGiaoDuc> data = await TbCoSoGiaoDucs();

            // Tạo một file Excel với EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách cơ sở giáo dục");

                // Hợp nhất và đặt tiêu đề lớn
                worksheet.Cells[1, 1, 1, 31].Merge = true;
                worksheet.Cells[1, 1].Value = "Báo cáo danh sách cơ sở giáo dục";
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Font.Size = 16;
                worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Tiêu đề bảng
                worksheet.Cells[2, 1].Value = "Stt";
                worksheet.Cells[2, 2].Value = "Mã Đơn Vị";
                worksheet.Cells[2, 3].Value = "Tên Đơn Vị";
                worksheet.Cells[2, 4].Value = "Tên Tiếng Anh";
                worksheet.Cells[2, 5].Value = "Số Quyết Định Chuyển Đổi Loại Hình";
                worksheet.Cells[2, 6].Value = "Ngày Ký Quyết Định Chuyển Đổi Loại Hình";
                worksheet.Cells[2, 7].Value = "Đại Học Trực Thuộc";
                worksheet.Cells[2, 8].Value = "SĐT";
                worksheet.Cells[2, 9].Value = "FAX";
                worksheet.Cells[2, 10].Value = "Email";
                worksheet.Cells[2, 11].Value = "Địa Chỉ Web";
                worksheet.Cells[2, 12].Value = "Quyết Định Thành Lâp";
                worksheet.Cells[2, 13].Value = "Ngày Ký Quyết Định Thành Lâp";
                worksheet.Cells[2, 14].Value = "Địa Chỉ";
                worksheet.Cells[2, 15].Value = "Quyết Định Cấp Phép Hoạt Động";
                worksheet.Cells[2, 16].Value = "Ngày Được Cấp Phép Hoạt Động";
                worksheet.Cells[2, 17].Value = "GV GSTC";
                worksheet.Cells[2, 18].Value = "QĐ Giao Từ Chủ";
                worksheet.Cells[2, 19].Value = "Đào Tạo SVDG QPAN 1 Năm";
                worksheet.Cells[2, 20].Value = "QĐ Ban Hành QCTC";
                worksheet.Cells[2, 21].Value = "Ngày Ký QĐ Ban Hành QCTC";
                worksheet.Cells[2, 22].Value = "HĐ Không Lợi Nhuận";
                worksheet.Cells[2, 23].Value = "Cơ Quan Chủ Quán";
                worksheet.Cells[2, 24].Value = "Hình Thức Thành Lập";
                worksheet.Cells[2, 25].Value = "Loại Hình CSĐT";
                worksheet.Cells[2, 26].Value = "Loại Hình Trường";
                worksheet.Cells[2, 27].Value = "Phân Loại Cơ Sở";
                worksheet.Cells[2, 28].Value = "Tỉnh";
                worksheet.Cells[2, 29].Value = "Huyện";
                worksheet.Cells[2, 30].Value = "Xã";
                worksheet.Cells[2, 31].Value = "Tự Chủ Giáo Dục";

                // Định dạng tiêu đề
                using (var range = worksheet.Cells[2, 1, 2, 31])
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
                    worksheet.Cells[row, 1].Value = item.IdCoSoGiaoDuc;
                    worksheet.Cells[row, 2].Value = item.MaDonVi;
                    worksheet.Cells[row, 3].Value = item.TenDonVi;
                    worksheet.Cells[row, 4].Value = item.TenTiengAnh;
                    worksheet.Cells[row, 5].Value = item.SoQuyetDinhChuyenDoiLoaiHinh;
                    worksheet.Cells[row, 6].Value = item.NgayKyQuyetDinhChuyenDoiLoaiHinh.HasValue ? item.NgayKyQuyetDinhChuyenDoiLoaiHinh.Value : (object)"";
                    worksheet.Cells[row, 6].Style.Numberformat.Format = "dd/MM/yyyy";
                    worksheet.Cells[row, 7].Value = item.TenDaiHocTrucThuoc;
                    worksheet.Cells[row, 8].Value = item.SoDienThoai;
                    worksheet.Cells[row, 9].Value = item.Fax;
                    worksheet.Cells[row, 10].Value = item.Email;
                    worksheet.Cells[row, 11].Value = item.DiaChiWebsite;
                    worksheet.Cells[row, 12].Value = item.SoQuyetDinhThanhLap;
                    worksheet.Cells[row, 13].Value = item.NgayKyQuyetDinhThanhLap.HasValue ? item.NgayKyQuyetDinhThanhLap.Value : (object)"";
                    worksheet.Cells[row, 13].Style.Numberformat.Format = "dd/MM/yyyy";
                    worksheet.Cells[row, 14].Value = item.DiaChi;
                    worksheet.Cells[row, 15].Value = item.SoQuyetDinhCapPhepHoatDong;
                    worksheet.Cells[row, 16].Value = item.NgayDuocCapPhepHoatDong.HasValue ? item.NgayDuocCapPhepHoatDong.Value : (object)"";
                    worksheet.Cells[row, 16].Style.Numberformat.Format = "dd/MM/yyyy";
                    worksheet.Cells[row, 17].Value = item.SoGiaoVienGdtc;
                    worksheet.Cells[row, 18].Value = item.SoQuyetDinhGiaoTuChu;
                    worksheet.Cells[row, 19].Value = item.DaoTaoSvgdqpan1nam;
                    worksheet.Cells[row, 20].Value = item.SoQuyetDinhBanHanhQuyCheTaiChinh;
                    worksheet.Cells[row, 21].Value = item.NgayKyQuyetDinhBanHanhQuyCheTaiChinh.HasValue ? item.NgayKyQuyetDinhBanHanhQuyCheTaiChinh.Value : (object)"";
                    worksheet.Cells[row, 21].Style.Numberformat.Format = "dd/MM/yyyy";
                    worksheet.Cells[row, 22].Value = item.HoatDongKhongLoiNhuanNavigation?.TuyChon;
                    worksheet.Cells[row, 23].Value = item.IdCoQuanChuQuanNavigation?.CoQuanChuQuan;
                    worksheet.Cells[row, 24].Value = item.IdHinhThucThanhLapNavigation?.HinhThucThanhLap;
                    worksheet.Cells[row, 25].Value = item.IdLoaiHinhCoSoDaoTaoNavigation?.LoaiHinhCoSoDaoTao;
                    worksheet.Cells[row, 26].Value = item.IdLoaiHinhTruongNavigation?.LoaiHinhTruong;
                    worksheet.Cells[row, 27].Value = item.IdPhanLoaiCoSoNavigation?.PhanLoaiCoSo;
                    worksheet.Cells[row, 28].Value = item.IdTinhNavigation?.TenTinh;
                    worksheet.Cells[row, 29].Value = item.IdHuyenNavigation?.TenHuyen;
                    worksheet.Cells[row, 30].Value = item.IdXaNavigation?.TenXa;
                    worksheet.Cells[row, 31].Value = item.TuChuGiaoDucQpanNavigation?.TuyChon;
                    row++;
                }

                // Thêm viền cho toàn bộ bảng
                worksheet.Cells[2, 1, row - 1, 31].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 31].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 31].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, row - 1, 31].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                worksheet.Cells.AutoFitColumns();

                var stream = new System.IO.MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = $"DanhSachCoSoGiaoDuc_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }

        // GET: CoSoGiaoDuc/Import
        public IActionResult Import()
        {
            return View();
        }

        // POST: CoSoGiaoDuc/Import
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
                    stream.Position = 0;

                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên
                        int rowCount = worksheet.Dimension.Rows; // Số lượng dòng

                        var tbCoCauToChucs = new List<TbCoSoGiaoDuc>();

                        // Duyệt qua từng dòng (bỏ qua dòng tiêu đề nếu có)
                        for (int row = 2; row <= rowCount; row++) // Giả sử dòng 1 là tiêu đề
                        {
                            var item = new TbCoSoGiaoDuc
                            {
                                IdCoSoGiaoDuc = int.Parse(worksheet.Cells[row, 1].Text),
                                MaDonVi = worksheet.Cells[row, 2].Text,
                                TenDonVi = worksheet.Cells[row, 3].Text,
                                TenTiengAnh = worksheet.Cells[row, 4].Text,
                                SoQuyetDinhChuyenDoiLoaiHinh = worksheet.Cells[row, 5].Text,
                                NgayKyQuyetDinhChuyenDoiLoaiHinh = DateTime.TryParseExact(worksheet.Cells[row, 6].Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate) ? DateOnly.FromDateTime(parsedDate) : null,
                                TenDaiHocTrucThuoc = worksheet.Cells[row, 7].Text,
                                SoDienThoai = worksheet.Cells[row, 8].Text,
                                Fax = worksheet.Cells[row, 9].Text,
                                Email = worksheet.Cells[row, 10].Text,
                                DiaChiWebsite = worksheet.Cells[row, 11].Text,
                                SoQuyetDinhThanhLap = worksheet.Cells[row, 12].Text,
                                NgayKyQuyetDinhThanhLap = DateTime.TryParseExact(worksheet.Cells[row, 13].Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate1) ? DateOnly.FromDateTime(parsedDate1) : null,
                                DiaChi = worksheet.Cells[row, 14].Text,
                                SoQuyetDinhCapPhepHoatDong = worksheet.Cells[row, 15].Text,
                                NgayDuocCapPhepHoatDong = DateTime.TryParseExact(worksheet.Cells[row, 16].Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate2) ? DateOnly.FromDateTime(parsedDate2) : null,
                                SoGiaoVienGdtc = int.Parse(worksheet.Cells[row, 17].Text),
                                SoQuyetDinhGiaoTuChu = worksheet.Cells[row, 18].Text,
                                DaoTaoSvgdqpan1nam = int.Parse(worksheet.Cells[row, 19].Text),
                                SoQuyetDinhBanHanhQuyCheTaiChinh = worksheet.Cells[row, 20].Text,
                                NgayKyQuyetDinhBanHanhQuyCheTaiChinh = DateTime.TryParseExact(worksheet.Cells[row, 21].Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate3) ? DateOnly.FromDateTime(parsedDate3) : null,
                                HoatDongKhongLoiNhuan = int.Parse(worksheet.Cells[row, 22].Text),
                                IdCoQuanChuQuan = int.Parse(worksheet.Cells[row, 23].Text),
                                IdHinhThucThanhLap = int.Parse(worksheet.Cells[row, 24].Text),
                                IdLoaiHinhCoSoDaoTao = int.Parse(worksheet.Cells[row, 25].Text),
                                IdLoaiHinhTruong = int.Parse(worksheet.Cells[row, 26].Text),
                                IdPhanLoaiCoSo = int.Parse(worksheet.Cells[row, 27].Text),
                                IdTinh = int.Parse(worksheet.Cells[row, 28].Text),
                                IdHuyen = int.Parse(worksheet.Cells[row, 29].Text),
                                IdXa = int.Parse(worksheet.Cells[row, 30].Text),
                                TuChuGiaoDucQpan = int.Parse(worksheet.Cells[row, 31].Text),
                            };


                            tbCoCauToChucs.Add(item);
                        }

                        // Gửi dữ liệu tới API để lưu vào database
                        foreach (var tbCoCauToChuc in tbCoCauToChucs)
                        {
                            await ApiServices_.Create<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc", tbCoCauToChuc);
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

        private async Task<bool> TbCoSoGiaoDucExists(int id)
        {
            var tbCoSoGiaoDucs = await ApiServices_.GetAll<TbCoSoGiaoDuc>("/api/csgd/CoSoGiaoDuc");
            return tbCoSoGiaoDucs.Any(x => x.IdCoSoGiaoDuc == id);
        }
    }
}
