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
namespace C500Hemis.Controllers.CSGD
{
    public class KhoaHocController : Controller
    {
        private readonly ApiServices ApiServices_;
        // Lấy từ HemisContext 
        public KhoaHocController(ApiServices services)
        {
            ApiServices_ = services;
        }

        // GET: ChuongTrinhDaoTao
        // Lấy danh sách CTĐT từ database, trả về view Index.

        private async Task<List<TbKhoaHoc>> TbKhoaHocs()
        {
            List<TbKhoaHoc> tbKhoaHocs = await ApiServices_.GetAll<TbKhoaHoc>("/api/csgd/KhoaHoc");
      
            return tbKhoaHocs;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<TbKhoaHoc> getall = await TbKhoaHocs();
                // Lấy data từ các table khác có liên quan (khóa ngoài) để hiển thị trên Index
                return View(getall);
                // Bắt lỗi các trường hợp ngoại lệ
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
                var tbKhoaHocs = await TbKhoaHocs();
                var tbKhoaHoc = tbKhoaHocs.FirstOrDefault(m => m.IdKhoaHoc == id);
                // Nếu không tìm thấy Id tương ứng, chương trình sẽ báo lỗi NotFound
                if (tbKhoaHoc == null)
                {
                    return NotFound();
                }
                // Nếu đã tìm thấy Id tương ứng, chương trình sẽ dẫn đến view Details
                // Hiển thị thông thi chi tiết CTĐT thành công
                return View(tbKhoaHoc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: ChuongTrinhDaoTao/Create
        // Hiển thị view Create để tạo một bản ghi CTĐT mới
        // Truyền data từ các table khác hiển thị tại view Create (khóa ngoài)
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewData["IdKhoaHoc"] = new SelectList(await ApiServices_.GetAll<TbKhoaHoc>("/api/csgd/KhoaHoc"), "IdKhoaHoc", "IdKhoaHoc");
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

        // Thêm một CTĐT mới vào Database nếu IdChuongTrinhDaoTao truyền vào không trùng với Id đã có trong Database
        // Trong trường hợp nhập trùng IdChuongTrinhDaoTao sẽ bắt lỗi
        // Bắt lỗi ngoại lệ sao cho người nhập BẮT BUỘC phải nhập khác IdChuongTrinhDaoTao đã có
        [HttpPost]
        [ValidateAntiForgeryToken] // Một phương thức bảo mật thông qua Token được tạo tự động cho các Form khác nhau
        public async Task<IActionResult> Create([Bind("IdKhoaHoc,TuNam,DenNam")] TbKhoaHoc tbKhoaHoc)
        {
            try
            {
                // Nếu trùng IDChuongTrinhDaoTao sẽ báo lỗi
                if (await TbKhoaHocExists(tbKhoaHoc.IdKhoaHoc)) ModelState.AddModelError("IdKhoaHoc", "ID này đã tồn tại!");
                if (ModelState.IsValid)
                {
                    await ApiServices_.Create<TbKhoaHoc>("/api/csgd/KhoaHoc", tbKhoaHoc);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["IdKhoaHoc"] = new SelectList(await ApiServices_.GetAll<TbKhoaHoc>("/api/csgd/KhoaHoc"), "IdKhoaHoc", "IdKhoaHoc", tbKhoaHoc.IdKhoaHoc);
               return View(tbKhoaHoc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // GET: ChuongTrinhDaoTao/Edit
        // Lấy data từ Database với Id đã có, sau đó hiển thị ở view Edit
        // Nếu không tìm thấy Id tương ứng sẽ báo lỗi NotFound
        // Phương thức này gần giống Create, nhưng nó nhập dữ liệu vào Id đã có trong database
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var tbKhoaHoc = await ApiServices_.GetId<TbKhoaHoc>("/api/csgd/KhoaHoc", id ?? 0);
                if (tbKhoaHoc == null)
                {
                    return NotFound();
                }
                ViewData["IdKhoaHoc"] = new SelectList(await ApiServices_.GetAll<TbKhoaHoc>("/api/csgd/KhoaHoc"), "IdKhoaHoc", "IdKhoaHoc", tbKhoaHoc.IdKhoaHoc);
                return View(tbKhoaHoc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // POST: ChuongTrinhDaoTao/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // Lưu data mới (ghi đè) vào các trường Data đã có thuộc IdChuongTrinhDaoTao cần chỉnh sửa
        // Nó chỉ cập nhật khi ModelState hợp lệ
        // Nếu không hợp lệ sẽ báo lỗi, vì vậy cần có bắt lỗi.

        [HttpPost]
        [ValidateAntiForgeryToken] // Một phương thức bảo mật thông qua Token được tạo tự động cho các Form khác nhau
        public async Task<IActionResult> Edit(int id,[Bind("IdKhoaHoc,TuNam,DenNam")] TbKhoaHoc tbKhoaHoc)
        {
            try
            {
                if (id != tbKhoaHoc.IdKhoaHoc)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        await ApiServices_.Update<TbKhoaHoc>("/api/csgd/KhoaHoc", id, tbKhoaHoc);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (await TbKhoaHocExists(tbKhoaHoc.IdKhoaHoc) == false)
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
                ViewData["IdKhoaHoc"] = new SelectList(await ApiServices_.GetAll<TbKhoaHoc>("/api/csgd/KhoaHoc"), "IdKhoaHoc", "IdKhoaHoc", tbKhoaHoc.IdKhoaHoc);
            return View(tbKhoaHoc);
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
                var tbKhoaHocs = await ApiServices_.GetAll<TbKhoaHoc>("/api/csgd/KhoaHoc");
                var tbKhoaHoc = tbKhoaHocs.FirstOrDefault(m => m.IdKhoaHoc == id);
                if (tbKhoaHoc == null)
                {
                    return NotFound();
                }

                return View(tbKhoaHoc);
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
                await ApiServices_.Delete<TbKhoaHoc>("/api/csgd/KhoaHoc", id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        private async Task<bool> TbKhoaHocExists(int id)
        {
            var tbKhoaHocs = await ApiServices_.GetAll<TbKhoaHoc>("/api/csgd/KhoaHoc");
            return tbKhoaHocs.Any(e => e.IdKhoaHoc == id);
        }
    }
}