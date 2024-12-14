using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmNgoaiNgu
{
    public int IdNgoaiNgu { get; set; }

    public string? NgoaiNgu { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNgonNguGiangDay> TbNgonNguGiangDays { get; set; } = new List<TbNgonNguGiangDay>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
