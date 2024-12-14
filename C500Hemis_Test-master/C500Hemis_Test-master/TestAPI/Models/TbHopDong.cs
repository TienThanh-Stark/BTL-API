using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbHopDong
{
    public int IdHopDong { get; set; }

    public int? IdCanBo { get; set; }

    public string? SoHopDong { get; set; }

    public int? IdLoaiHopDong { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayQuyetDinh { get; set; }

    public DateOnly? CoGiaTriTu { get; set; }

    public DateOnly? CoGiaTriDen { get; set; }

    public int? IdTinhTrangHopDong { get; set; }

    public bool? LamViecToanThoiGian { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmLoaiHopDong? IdLoaiHopDongNavigation { get; set; }

    public virtual DmTinhTrangHopDong? IdTinhTrangHopDongNavigation { get; set; }
}
