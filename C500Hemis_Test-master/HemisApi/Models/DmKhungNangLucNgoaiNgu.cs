using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmKhungNangLucNgoaiNgu
{
    public int IdKhungNangLucNgoaiNgu { get; set; }

    public string? TenKhungNangLucNgoaiNgu { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNgonNguGiangDay> TbNgonNguGiangDays { get; set; } = new List<TbNgonNguGiangDay>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbTrinhDoTiengDanToc> TbTrinhDoTiengDanTocs { get; set; } = new List<TbTrinhDoTiengDanToc>();
}
