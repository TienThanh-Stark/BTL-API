using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmDauMoiLienHe
{
    public int IdDauMoiLienHe { get; set; }

    public string? DauMoiLienHe { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDauMoiLienHe> TbDauMoiLienHes { get; set; } = new List<TbDauMoiLienHe>();
}
