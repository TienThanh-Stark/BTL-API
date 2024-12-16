using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbNgonNguGiangDay
{
    public int IdNgonNguGiangDay { get; set; }

    public int? IdChuongTrinhDaoTao { get; set; }

    public int? IdNgonNgu { get; set; }

    public int? IdTrinhDoNgonNguDauVao { get; set; }

    public virtual TbChuongTrinhDaoTao? IdChuongTrinhDaoTaoNavigation { get; set; }

    public virtual DmNgoaiNgu? IdNgonNguNavigation { get; set; }

    public virtual DmKhungNangLucNgoaiNgu? IdTrinhDoNgonNguDauVaoNavigation { get; set; }
}
