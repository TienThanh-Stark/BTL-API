using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmChuSoHuu
{
    public int IdChuSoHuu { get; set; }

    public string? ChuSoHuu { get; set; }

    public virtual ICollection<TbChiTietTaiSanDonVi> TbChiTietTaiSanDonVis { get; set; } = new List<TbChiTietTaiSanDonVi>();
}
