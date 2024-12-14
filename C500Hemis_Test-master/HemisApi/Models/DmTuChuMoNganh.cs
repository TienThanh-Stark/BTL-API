using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTuChuMoNganh
{
    public int IdTuChuMoNganh { get; set; }

    public string? TuChuMoNganh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaos { get; set; } = new List<TbDanhSachNganhDaoTao>();
}
