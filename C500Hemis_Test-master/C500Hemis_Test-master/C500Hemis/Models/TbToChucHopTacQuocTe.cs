using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbToChucHopTacQuocTe
{
    public int IdToChucHopTacQuocTe { get; set; }

    public string? MaHopTac { get; set; }

    public string? TenToChuc { get; set; }

    public int? IdQuocGia { get; set; }

    public string? NoiDung { get; set; }

    public DateTime? ThoiGianKyKet { get; set; }

    public string? KetQuaHopTac { get; set; }

    public string? LoaiToChuc { get; set; }

    public virtual DmQuocTich? IdQuocGiaNavigation { get; set; }

    public virtual ICollection<TbThongTinHopTac> TbThongTinHopTacs { get; set; } = new List<TbThongTinHopTac>();
}
