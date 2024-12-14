using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmChucDanhGiangVien
{
    public int IdChucDanhGiangVien { get; set; }

    public string? ChucDanhGiangVien { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbQuaTrinhCongTacCuaCanBo> TbQuaTrinhCongTacCuaCanBos { get; set; } = new List<TbQuaTrinhCongTacCuaCanBo>();
}
