using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiSachTapChi
{
    public int IdLoaiSachTapChi { get; set; }

    public string? LoaiSachTapChi { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbSachDaXuatBan> TbSachDaXuatBans { get; set; } = new List<TbSachDaXuatBan>();
}
