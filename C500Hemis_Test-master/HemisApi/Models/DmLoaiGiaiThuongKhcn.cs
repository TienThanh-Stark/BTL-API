using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiGiaiThuongKhcn
{
    public int IdLoaiGiaiThuongKhcn { get; set; }

    public string? LoaiGiaiThuongKhcn { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbGiaiThuongKhoaHoc> TbGiaiThuongKhoaHocs { get; set; } = new List<TbGiaiThuongKhoaHoc>();
}
