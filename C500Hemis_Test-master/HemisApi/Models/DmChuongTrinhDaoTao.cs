using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmChuongTrinhDaoTao
{
    public int IdChuongTrinhDaoTao { get; set; }

    public string? ChuongTrinhDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
