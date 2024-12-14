using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmKetQuaKiemDinh
{
    public int IdKetQuaKiemDinh { get; set; }

    public string? KetQuaKiemDinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinKiemDinhCuaChuongTrinh> TbThongTinKiemDinhCuaChuongTrinhs { get; set; } = new List<TbThongTinKiemDinhCuaChuongTrinh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbToChucKiemDinh> TbToChucKiemDinhs { get; set; } = new List<TbToChucKiemDinh>();
}
