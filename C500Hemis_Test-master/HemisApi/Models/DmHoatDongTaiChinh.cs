using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHoatDongTaiChinh
{
    public int IdHoatDongTaiChinh { get; set; }

    public string? HoatDongTaiChinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHoatDongTaiChinh> TbHoatDongTaiChinhs { get; set; } = new List<TbHoatDongTaiChinh>();
}
