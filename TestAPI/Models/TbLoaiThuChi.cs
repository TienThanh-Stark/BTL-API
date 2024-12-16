using System;
using System.Collections.Generic;

namespace TestAPI.Models;

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
