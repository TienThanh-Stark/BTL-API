using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class TbKhoiNganhDaoTao
{
    public int IdKhoiNganhDaoTao { get; set; }

    public string? KhoiNganhDaoTao { get; set; }

    public virtual ICollection<DmKhoiNganhLinhVucDaoTao> DmKhoiNganhLinhVucDaoTaos { get; set; } = new List<DmKhoiNganhLinhVucDaoTao>();

    public virtual ICollection<TbThongTinLinhVucDaoTao> TbThongTinLinhVucDaoTaos { get; set; } = new List<TbThongTinLinhVucDaoTao>();
}
