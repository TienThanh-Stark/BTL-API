using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmDoiTuongDauVao
{
    public int IdDoiTuongDauVao { get; set; }

    public string? DoiTuongDauVao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDuLieuTrungTuyen> TbDuLieuTrungTuyens { get; set; } = new List<TbDuLieuTrungTuyen>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
