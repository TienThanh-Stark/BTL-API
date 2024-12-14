using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiKyLuat
{
    public int IdLoaiKyLuat { get; set; }

    public string? LoaiKyLuat { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbKyLuatCanBo> TbKyLuatCanBos { get; set; } = new List<TbKyLuatCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbKyLuatNguoiHoc> TbKyLuatNguoiHocs { get; set; } = new List<TbKyLuatNguoiHoc>();
}
