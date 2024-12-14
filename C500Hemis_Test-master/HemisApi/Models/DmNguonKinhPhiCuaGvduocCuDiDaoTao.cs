using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmNguonKinhPhiCuaGvduocCuDiDaoTao
{
    public int IdNguonKinhPhiCuaGvduocCuDiDaoTao { get; set; }

    public string? NguonKinhPhiCuaGvduocCuDiDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbGvduocCuDiDaoTao> TbGvduocCuDiDaoTaos { get; set; } = new List<TbGvduocCuDiDaoTao>();
}
