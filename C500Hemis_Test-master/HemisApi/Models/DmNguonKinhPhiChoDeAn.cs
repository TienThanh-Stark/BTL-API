using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmNguonKinhPhiChoDeAn
{
    public int IdNguonKinhPhiChoDeAn { get; set; }

    public string? NguonKinhPhiChoDeAn { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDeAnDuAnChuongTrinh> TbDeAnDuAnChuongTrinhs { get; set; } = new List<TbDeAnDuAnChuongTrinh>();
}
