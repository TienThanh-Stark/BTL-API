using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmPhanLoaiThuChi
{
    public int IdPhanLoaiThuChi { get; set; }

    public string? PhanLoaiThuChi { get; set; }

    public virtual ICollection<TbLoaiThuChi> TbLoaiThuChis { get; set; } = new List<TbLoaiThuChi>();
}
