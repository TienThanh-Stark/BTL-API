using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbLoaiThuChi
{
    public int IdLoaiThuChi { get; set; }

    public string? MaLoaiThuChi { get; set; }

    public int? IdPhanLoaiThuChi { get; set; }

    public string? TenLoaiThuChi { get; set; }

    public string? MoTa { get; set; }

    public virtual DmPhanLoaiThuChi? IdPhanLoaiThuChiNavigation { get; set; }

    public virtual ICollection<TbChiTietThuChi> TbChiTietThuChis { get; set; } = new List<TbChiTietThuChi>();
}
