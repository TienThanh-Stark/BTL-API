using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmChucDanhKhoaHoc
{
    public int IdChucDanhKhoaHoc { get; set; }

    public string? ChucDanhKhoaHoc { get; set; }

    public virtual ICollection<TbChucDanhKhoaHocCuaCanBo> TbChucDanhKhoaHocCuaCanBos { get; set; } = new List<TbChucDanhKhoaHocCuaCanBo>();

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
