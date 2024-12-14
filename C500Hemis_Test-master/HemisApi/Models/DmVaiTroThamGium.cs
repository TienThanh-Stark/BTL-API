using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmVaiTroThamGia
{
    public int IdVaiTroThamGia { get; set; }

    public string? VaiTroThamGia { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDoiTuongThamGium> TbDoiTuongThamGia { get; set; } = new List<TbDoiTuongThamGium>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThanhPhanThamGiaDoanCongTac> TbThanhPhanThamGiaDoanCongTacs { get; set; } = new List<TbThanhPhanThamGiaDoanCongTac>();
}
