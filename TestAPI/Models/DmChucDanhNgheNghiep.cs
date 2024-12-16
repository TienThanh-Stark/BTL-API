using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmChucDanhNgheNghiep
{
    public int IdChucDanhNgheNghiep { get; set; }

    public string? ChucDanhNgheNghiep { get; set; }

    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();
}
