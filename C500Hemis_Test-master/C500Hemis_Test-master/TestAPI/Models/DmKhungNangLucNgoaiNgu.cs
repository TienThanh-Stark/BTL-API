using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmKhungNangLucNgoaiNgu
{
    public int IdKhungNangLucNgoaiNgu { get; set; }

    public string? TenKhungNangLucNgoaiNgu { get; set; }

    public virtual ICollection<TbNgonNguGiangDay> TbNgonNguGiangDays { get; set; } = new List<TbNgonNguGiangDay>();

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();

    public virtual ICollection<TbTrinhDoTiengDanToc> TbTrinhDoTiengDanTocs { get; set; } = new List<TbTrinhDoTiengDanToc>();
}
