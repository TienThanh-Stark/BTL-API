using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbPhongHocGiangDuongHoiTruong
{
    public int IdPhongHocGiangDuongHoiTruong { get; set; }

    public string? MaPhongHocGiangDuongHoiTruong { get; set; }

    public string? TenPhongHocGiangDuongHoiTruong { get; set; }

    public double? DienTich { get; set; }

    public int? IdHinhThucSoHuu { get; set; }

    public int? QuyMoChoNgoi { get; set; }

    public int? IdTinhTrangCoSoVatChat { get; set; }

    public int? IdPhanLoaiCsvc { get; set; }

    public int? IdLoaiPhongHoc { get; set; }

    public int? IdLoaiDeAn { get; set; }

    public string? NamDuaVaoSuDung { get; set; }

    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }

    public virtual DmLoaiDeAnChuongTrinh? IdLoaiDeAnNavigation { get; set; }

    public virtual DmLoaiPhongHoc? IdLoaiPhongHocNavigation { get; set; }

    public virtual DmPhanLoaiCsvc? IdPhanLoaiCsvcNavigation { get; set; }

    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCoSoVatChatNavigation { get; set; }
}
