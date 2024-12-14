using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTrangThaiChuongTrinhDaoTao
{
    public int IdTrangThaiChuongTrinhDaoTao { get; set; }

    public string? TrangThaiChuongTrinhDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();
}
