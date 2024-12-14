using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbCanBoHuongDanThanhCongSinhVien
{
    public int IdCanBoHuongDanThanhCongSinhVien { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdSinhVien { get; set; }

    public string? TrachNhiemHuongDan { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }
}
