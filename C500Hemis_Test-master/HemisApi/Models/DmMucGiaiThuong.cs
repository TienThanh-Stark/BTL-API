using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmMucGiaiThuong
{
    public int IdMucGiaiThuong { get; set; }

    public string? MucGiaiThuong { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbGiaiThuongKhoaHoc> TbGiaiThuongKhoaHocs { get; set; } = new List<TbGiaiThuongKhoaHoc>();
}
