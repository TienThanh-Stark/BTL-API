using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTrangThaiHoc
{
    public int IdTrangThaiHoc { get; set; }

    public string? TrangThaiHoc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
