using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmHocCheDaoTao
{
    public int IdHocCheDaoTao { get; set; }

    public string? HocCheDaoTao { get; set; }

    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();
}
