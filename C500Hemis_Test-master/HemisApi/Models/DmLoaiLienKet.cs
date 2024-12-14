using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiLienKet
{
    public int IdLoaiLienKet { get; set; }

    public string? LoaiLienKet { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDonViLienKetDaoTaoGiaoDuc> TbDonViLienKetDaoTaoGiaoDucs { get; set; } = new List<TbDonViLienKetDaoTaoGiaoDuc>();
}
