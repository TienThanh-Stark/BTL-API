using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd
{
    public int IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd { get; set; }

    public int? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }

    public int? IdDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }

    public string? SoQuyetDinhKhenThuong { get; set; }

    public int? IdPhuongThucKhenThuong { get; set; }

    public string? NamKhenThuong { get; set; }

    public int? IdCapKhenThuong { get; set; }

    public virtual DmCapKhenThuong? IdCapKhenThuongNavigation { get; set; }

    public virtual DmThiDuaGiaiThuongKhenThuong IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdNavigation { get; set; } = null!;

    public virtual DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }

    public virtual DmPhuongThucKhenThuong? IdPhuongThucKhenThuongNavigation { get; set; }
}
