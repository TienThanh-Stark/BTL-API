using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbNhomNghienCuuManh
{
    public int IdNhomNghienCuuManh { get; set; }

    public string? MaNhomNghienCuuManh { get; set; }

    public string? TenNhomNghienCuuManh { get; set; }

    public string? SoQuyetDinhThanhLap { get; set; }

    public string? ToChucBanHanhQuyetDinh { get; set; }

    public DateOnly? NgayQuyetDinh { get; set; }

    public string? CacNhiemVuNckh { get; set; }

    public string? TomTatKetQuaDatDuoc { get; set; }
}
