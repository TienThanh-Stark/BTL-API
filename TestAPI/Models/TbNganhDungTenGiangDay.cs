using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbNganhDungTenGiangDay
{
    public int IdNganhDungTenGiangDay { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdNganhDaoTao { get; set; }

    public double? TrongSo { get; set; }

    public string? TenCanBo { get; set; }

    public string? TenNganhGiangDay { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmNganhDaoTao? IdNganhDaoTaoNavigation { get; set; }
}
