using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiThamGia
{
    public int IdLoaiThamGia { get; set; }

    public string? LoaiThamGia { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDoiTuongThamGium> TbDoiTuongThamGia { get; set; } = new List<TbDoiTuongThamGium>();
}
