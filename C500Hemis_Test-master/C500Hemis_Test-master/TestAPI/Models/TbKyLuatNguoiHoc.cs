using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbKyLuatNguoiHoc
{
    public int IdKyLuatNguoiHoc { get; set; }

    public int? IdHocVien { get; set; }

    public int? IdLoaiKyLuat { get; set; }

    public string? LyDo { get; set; }

    public int? IdCapQuyetDinh { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayQuyetDinh { get; set; }

    public string? NamBiKyLuat { get; set; }

    public virtual DmCapKhenThuong? IdCapQuyetDinhNavigation { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmLoaiKyLuat? IdLoaiKyLuatNavigation { get; set; }
}
