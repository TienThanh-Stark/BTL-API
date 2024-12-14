using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmMucDichSuDungCsvc
{
    public int IdMucDichSuDungCsvc { get; set; }

    public string? MucDichSuDungCsvc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; } = new List<TbCongTrinhCoSoVatChat>();
}
