using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbBaiBaoKhdaCongBo
{
    public int IdBaiBaoKhdaCongBo { get; set; }

    public int? IdNhiemVuKhcn { get; set; }

    public string? MaBaiBaoKh { get; set; }

    public string? TenBaiBaoKh { get; set; }

    public string? TenTapChi { get; set; }

    public int? IdTapChiTrongNuoc { get; set; }

    public int? IdTapChiQuocTe { get; set; }

    public int? IdXepHangQ { get; set; }

    public string? GhiChuDuongDanBaiBao { get; set; }

    public int? TapSo { get; set; }

    public int? Trang { get; set; }

    public string? NamCongBo { get; set; }

    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }

    public virtual DmTapChiKhoaHocQuocTe? IdTapChiQuocTeNavigation { get; set; }

    public virtual DmTapChiTrongNuoc? IdTapChiTrongNuocNavigation { get; set; }

    public virtual DmXepHangQ? IdXepHangQNavigation { get; set; }
}
