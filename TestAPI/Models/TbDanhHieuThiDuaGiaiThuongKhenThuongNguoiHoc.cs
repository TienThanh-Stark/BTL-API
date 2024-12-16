using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc
{
    public int IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc { get; set; }

    public int? IdHocVien { get; set; }

    public int? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }

    public int? IdDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }

    public string? SoQuyetDinhKhenThuong { get; set; }

    public int? IdPhuongThucKhenThuong { get; set; }

    public string? NamKhenThuong { get; set; }

    public int? IdCapKhenThuong { get; set; }

    public virtual DmCapKhenThuong? IdCapKhenThuongNavigation { get; set; }

    public virtual DmThiDuaGiaiThuongKhenThuong? IdDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }

    public virtual DmPhuongThucKhenThuong? IdPhuongThucKhenThuongNavigation { get; set; }
}
