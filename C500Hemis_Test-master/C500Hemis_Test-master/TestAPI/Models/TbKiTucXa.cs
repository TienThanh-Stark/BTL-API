using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbKiTucXa
{
    public int IdKiTucXa { get; set; }

    public string? MaKyTucxa { get; set; }

    public int? IdHinhThucSoHuu { get; set; }

    public int? TongChoO { get; set; }

    public double? TongDienTich { get; set; }

    public int? IdTinhTrangCsvc { get; set; }

    public int? SoPhong { get; set; }

    public string? NamDuaVaoSuDung { get; set; }

    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }

    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }
}
