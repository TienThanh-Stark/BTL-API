using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThongTinHopTac
{
    public int IdThongTinHopTac { get; set; }

    public int? IdToChucHopTac { get; set; }

    public DateTime? ThoiGianHopTacTu { get; set; }

    public DateTime? ThoiGianHopTacDen { get; set; }

    public string? TenThoaThuan { get; set; }

    public string? ThongTinLienHeDoiTac { get; set; }

    public string? MucTieu { get; set; }

    public string? DonViTrienKhai { get; set; }

    public int? IdHinhThucHopTac { get; set; }

    public string? SanPhamChinh { get; set; }

    public virtual DmHinhThucHopTac? IdHinhThucHopTacNavigation { get; set; }

    public virtual TbToChucHopTacQuocTe? IdToChucHopTacNavigation { get; set; }
}
