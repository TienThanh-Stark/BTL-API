using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHinhThucHopTac
{
    public int IdHinhThucHopTac { get; set; }

    public string? HinhThucHopTac { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinHopTac> TbThongTinHopTacs { get; set; } = new List<TbThongTinHopTac>();
}
