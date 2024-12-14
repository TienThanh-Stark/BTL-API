using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbDatDai
{
    public int IdDatDai { get; set; }

    public string? MaGiayChungNhanQuyenSoHuu { get; set; }

    public double? DienTichDat { get; set; }

    public int? IdHinhThucSoHuu { get; set; }

    public string? TenDonViSoHuu { get; set; }

    public string? MinhChungQuyenSoHuuDatDai { get; set; }

    public string? MucDichSuDungDat { get; set; }

    public int? ThoiGianSuDungDat { get; set; }

    public double? DienTichDatDaSuDung { get; set; }

    public string? NamBatDauSuDungDat { get; set; }

    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }
}
