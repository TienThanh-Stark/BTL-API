using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class TbThongTinViPham
{
    public int IdThongTinViPham { get; set; }

    public int? IdHocVien { get; set; }

    public DateOnly? ThoiGianViPham { get; set; }

    public string? NoiDungViPham { get; set; }

    public string? HinhThucXuLy { get; set; }

    public int? IdLoaiViPham { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmLoaiViPham? IdLoaiViPhamNavigation { get; set; }
}
