using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmSinhVienNam
{
    public int IdSinhVienNam { get; set; }

    public string? SinhVienNam { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
