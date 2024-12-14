using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTapChiTrongNuoc
{
    public int IdTapChiTrongNuoc { get; set; }

    public string? TapChiTrongNuoc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbBaiBaoKhdaCongBo> TbBaiBaoKhdaCongBos { get; set; } = new List<TbBaiBaoKhdaCongBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbTapChiKhoaHoc> TbTapChiKhoaHocs { get; set; } = new List<TbTapChiKhoaHoc>();
}
