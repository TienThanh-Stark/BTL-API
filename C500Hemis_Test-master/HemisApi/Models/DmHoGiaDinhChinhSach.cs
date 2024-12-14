using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHoGiaDinhChinhSach
{
    public int IdHoGiaDinhChinhSach { get; set; }

    public string? HoGiaDinhChinhSach { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
