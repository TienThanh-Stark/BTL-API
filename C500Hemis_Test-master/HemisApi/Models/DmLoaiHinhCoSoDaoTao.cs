using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiHinhCoSoDaoTao
{
    public int IdLoaiHinhCoSoDaoTao { get; set; }

    public string? LoaiHinhCoSoDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();
}
