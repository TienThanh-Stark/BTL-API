using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmQuanHam
{
    public int IdQuanHam { get; set; }

    public string? QuanHam { get; set; }

    public virtual ICollection<TbGiaoVienQpan> TbGiaoVienQpans { get; set; } = new List<TbGiaoVienQpan>();
}
