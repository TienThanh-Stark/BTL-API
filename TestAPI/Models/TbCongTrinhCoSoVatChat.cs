using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbCongTrinhCoSoVatChat
{
    public int IdCongTrinhCoSoVatChat { get; set; }

    public string? MaCongTrinh { get; set; }

    public string? TenCongTrinh { get; set; }

    public int? IdLoaiCongTrinh { get; set; }

    public int? IdMucDichSuDung { get; set; }

    public string? DoiTuongSuDung { get; set; }

    public double? DienTichSanXayDung { get; set; }

    public double? VonBanDau { get; set; }

    public double? VonDauTu { get; set; }

    public int? IdTinhTrangCsvc { get; set; }

    public int? IdHinhThucSoHuu { get; set; }

    public int? CongTrinhCsvctrongNha { get; set; }

    public int? SoPhongOcongVu { get; set; }

    public int? SoChoOchoCanBoGiangDay { get; set; }

    public string? NamDuaVaoSuDung { get; set; }

    public virtual DmTuyChon? CongTrinhCsvctrongNhaNavigation { get; set; }

    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }

    public virtual DmLoaiCongTrinhCoSoVatChat? IdLoaiCongTrinhNavigation { get; set; }

    public virtual DmMucDichSuDungCsvc? IdMucDichSuDungNavigation { get; set; }

    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }

    public virtual ICollection<TbPhongThiNghiem> TbPhongThiNghiems { get; set; } = new List<TbPhongThiNghiem>();

    public virtual ICollection<TbPhongThucHanh> TbPhongThucHanhs { get; set; } = new List<TbPhongThucHanh>();

    public virtual ICollection<TbThietBiPtnThtren500Tr> TbThietBiPtnThtren500Trs { get; set; } = new List<TbThietBiPtnThtren500Tr>();
}
