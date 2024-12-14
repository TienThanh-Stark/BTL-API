using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiKhuyetTat
{
    public int IdLoaiKhuyetTat { get; set; }

    public string? LoaiKhuyetTat { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
}
