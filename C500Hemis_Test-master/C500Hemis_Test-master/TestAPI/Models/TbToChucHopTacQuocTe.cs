using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbToChucHopTacQuocTe
{
    public int IdToChucHopTacQuocTe { get; set; }

    public string? MaHopTac { get; set; }

    public string? TenToChuc { get; set; }

    public int? IdQuocGia { get; set; }

    public string? NoiDung { get; set; }

    public DateOnly? ThoiGianKyKet { get; set; }

    public string? KetQuaHopTac { get; set; }

    public string? LoaiToChuc { get; set; }

    public virtual DmQuocTich? IdQuocGiaNavigation { get; set; }

    public virtual ICollection<TbThongTinHopTac> TbThongTinHopTacs { get; set; } = new List<TbThongTinHopTac>();
}
