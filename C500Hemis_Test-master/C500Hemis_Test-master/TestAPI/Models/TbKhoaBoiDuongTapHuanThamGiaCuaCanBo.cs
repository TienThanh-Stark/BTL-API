using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbKhoaBoiDuongTapHuanThamGiaCuaCanBo
{
    public int IdKhoaBoiDuongTapHuanThamGiaCuaCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public string? TenKhoaBoiDuongTapHuan { get; set; }

    public string? DonViToChuc { get; set; }

    public int? IdLoaiBoiDuong { get; set; }

    public string? DiaDiemToChuc { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public int? IdNguonKinhPhi { get; set; }

    public string? ChungChi { get; set; }

    public DateOnly? NgayCap { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmLoaiBoiDuong? IdLoaiBoiDuongNavigation { get; set; }

    public virtual DmNguonKinhPhi? IdNguonKinhPhiNavigation { get; set; }
}
