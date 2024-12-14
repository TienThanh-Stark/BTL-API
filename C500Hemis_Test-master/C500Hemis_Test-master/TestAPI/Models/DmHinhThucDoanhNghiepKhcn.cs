using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmHinhThucDoanhNghiepKhcn
{
    public int IdHinhThucDoanhNghiepKhcn { get; set; }

    public string? HinhThucDoanhNghiepKhcn { get; set; }

    public virtual ICollection<TbDoanhNghiepKhcn> TbDoanhNghiepKhcns { get; set; } = new List<TbDoanhNghiepKhcn>();
}
