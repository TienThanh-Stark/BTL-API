using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLinhVucDaoTao
{
    public int IdLinhVucDaoTao { get; set; }

    public string? LinhVucDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<DmKhoiNganhLinhVucDaoTao> DmKhoiNganhLinhVucDaoTaos { get; set; } = new List<DmKhoiNganhLinhVucDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<DmLinhVucNhomNganh> DmLinhVucNhomNganhs { get; set; } = new List<DmLinhVucNhomNganh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNhomNganhDaoTao> TbNhomNganhDaoTaos { get; set; } = new List<TbNhomNganhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinLinhVucDaoTao> TbThongTinLinhVucDaoTaos { get; set; } = new List<TbThongTinLinhVucDaoTao>();
}
