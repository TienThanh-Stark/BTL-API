using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbThongTinHocBong
{
    public int IdThongTinHocBong { get; set; }

    public int? IdHocVien { get; set; }

    public string? TenHocBong { get; set; }

    public string? DonViTaiTro { get; set; }

    public DateOnly? ThoiGianTraoTangHocBong { get; set; }

    public int? IdLoaiHocBong { get; set; }

    public int? GiaTriHocBong { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmLoaiHocBong? IdLoaiHocBongNavigation { get; set; }
}
