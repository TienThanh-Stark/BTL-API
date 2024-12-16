using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbNganhGiangDayCuaCanBo
{
    public int IdNganhGiangDayCuaCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdTrinhDoDaoTao { get; set; }

    public int? IdNganh { get; set; }

    public bool? LaNganhChinh { get; set; }

    public string? DonViThinhGiang { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmNganhDaoTao? IdNganhNavigation { get; set; }

    public virtual DmTrinhDoDaoTao? IdTrinhDoDaoTaoNavigation { get; set; }
}
