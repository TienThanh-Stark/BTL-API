using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiHinhTruong
{
    public int IdLoaiHinhTruong { get; set; }

    public string? LoaiHinhTruong { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();
}
