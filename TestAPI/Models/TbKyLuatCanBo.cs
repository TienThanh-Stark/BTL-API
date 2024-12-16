using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbKyLuatCanBo
{
    public int IdKyLuatCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdLoaiKyLuat { get; set; }

    public string? LyDo { get; set; }

    public int? IdCapQuyetDinh { get; set; }

    public DateOnly? NgayThangNamQuyetDinh { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NamBiKyLuat { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmCapKhenThuong? IdCapQuyetDinhNavigation { get; set; }

    public virtual DmLoaiKyLuat? IdLoaiKyLuatNavigation { get; set; }
}
