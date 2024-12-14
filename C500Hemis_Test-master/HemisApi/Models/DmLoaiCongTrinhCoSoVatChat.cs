using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiCongTrinhCoSoVatChat
{
    public int IdLoaiCongTrinhCoSoVatChat { get; set; }

    public string? LoaiCongTrinhCoSoVatChat { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; } = new List<TbCongTrinhCoSoVatChat>();
}
