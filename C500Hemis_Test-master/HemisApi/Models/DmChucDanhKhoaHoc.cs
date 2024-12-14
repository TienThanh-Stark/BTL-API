using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmChucDanhKhoaHoc
{
    public int IdChucDanhKhoaHoc { get; set; }

    public string? ChucDanhKhoaHoc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChucDanhKhoaHocCuaCanBo> TbChucDanhKhoaHocCuaCanBos { get; set; } = new List<TbChucDanhKhoaHocCuaCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
