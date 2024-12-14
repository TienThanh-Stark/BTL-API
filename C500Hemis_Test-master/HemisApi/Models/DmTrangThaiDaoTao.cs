using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTrangThaiDaoTao
{
    public int IdTrangThaiDaoTao { get; set; }

    public string? TrangThaiDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaos { get; set; } = new List<TbDanhSachNganhDaoTao>();
}
