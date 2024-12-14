using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTrinhDoDaoTao
{
    public int IdTrinhDoDaoTao { get; set; }

    public string? TrinhDoDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDienBienLuong> TbDienBienLuongs { get; set; } = new List<TbDienBienLuong>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNganhGiangDayCuaCanBo> TbNganhGiangDayCuaCanBos { get; set; } = new List<TbNganhGiangDayCuaCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; } = new List<TbQuaTrinhDaoTaoCuaCanBo>();
}
