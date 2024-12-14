using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmPhanLoaiThuChi
{
    public int IdPhanLoaiThuChi { get; set; }

    public string? PhanLoaiThuChi { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbLoaiThuChi> TbLoaiThuChis { get; set; } = new List<TbLoaiThuChi>();
}
