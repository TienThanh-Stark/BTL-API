using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmToChucKiemDinh
{
    public int IdToChucKiemDinh { get; set; }

    public string? ToChucKiemDinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinKiemDinhCuaChuongTrinh> TbThongTinKiemDinhCuaChuongTrinhs { get; set; } = new List<TbThongTinKiemDinhCuaChuongTrinh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbToChucKiemDinh> TbToChucKiemDinhs { get; set; } = new List<TbToChucKiemDinh>();
}
