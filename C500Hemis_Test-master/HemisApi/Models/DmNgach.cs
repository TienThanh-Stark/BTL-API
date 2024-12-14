using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmNgach
{
    public int IdNgach { get; set; }

    public string? Ngach { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();
}
