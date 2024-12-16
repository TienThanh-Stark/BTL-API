using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbCoCauToChuc
{
    public int IdCoCauToChuc { get; set; }

    public string? MaPhongBanDonVi { get; set; }

    public int? IdLoaiPhongBan { get; set; }

    public string? MaPhongBanDonViCha { get; set; }

    public string? TenPhongBanDonVi { get; set; }

    public string? SoQuyetDinhThanhLap { get; set; }

    public string? NgayRaQuyetDinh { get; set; }

    public int? IdTrangThai { get; set; }

    public virtual DmLoaiPhongBan? IdLoaiPhongBanNavigation { get; set; }

    public virtual DmTrangThaiCoSoGd? IdTrangThaiNavigation { get; set; }
}
