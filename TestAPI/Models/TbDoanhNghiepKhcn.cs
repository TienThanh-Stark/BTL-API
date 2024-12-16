using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbDoanhNghiepKhcn
{
    public int IdDoanhNghiepKhcn { get; set; }

    public string? MaDoanhNghiep { get; set; }

    public string? TenDoanhNghiep { get; set; }

    public int? IdHinhThucDoanhNghiepKhcn { get; set; }

    public string? DiaDiemThanhLap { get; set; }

    public int? QuyMoDauTu { get; set; }

    public string? KinhPhiGopVonTuTaiSanTriTue { get; set; }

    public int? TyLeGopVonCuaCsgddh { get; set; }

    public virtual DmHinhThucDoanhNghiepKhcn? IdHinhThucDoanhNghiepKhcnNavigation { get; set; }
}
