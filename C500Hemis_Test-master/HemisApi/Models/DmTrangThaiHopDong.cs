using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTrangThaiHopDong
{
    public int IdTrangThaiHopDong { get; set; }

    public string? TrangThaiHopDong { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; } = new List<TbChuyenGiaoCongNgheVaDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHopDongThinhGiang> TbHopDongThinhGiangs { get; set; } = new List<TbHopDongThinhGiang>();
}
