using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiChuongTrinhLienKetDaoTao
{
    public int IdLoaiChuongTrinhLienKetDaoTao { get; set; }

    public string? LoaiChuongTrinhLienKetDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();
}
