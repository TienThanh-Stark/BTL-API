using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHinhThucThanhLap
{
    public int IdHinhThucThanhLap { get; set; }

    public string? HinhThucThanhLap { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();
}
