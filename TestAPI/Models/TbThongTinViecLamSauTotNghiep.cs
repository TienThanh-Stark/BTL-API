using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbThongTinViecLamSauTotNghiep
{
    public int IdThongTinViecLamSauTotNghiep { get; set; }

    public int? IdHocVien { get; set; }

    public string? TenDonViCapBang { get; set; }

    public string? DonViTuyenDung { get; set; }

    public int? IdHinhThucTuyenDung { get; set; }

    public DateOnly? ThoiGianTuyenDung { get; set; }

    public int? IdViTriViecLam { get; set; }

    public int? MucLuongKhoiDiem { get; set; }

    public virtual DmHinhThucTuyenDung? IdHinhThucTuyenDungNavigation { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmViTriViecLam? IdViTriViecLamNavigation { get; set; }
}
