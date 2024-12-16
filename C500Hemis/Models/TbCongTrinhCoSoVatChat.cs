using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbCongTrinhCoSoVatChat
{
    public int IdCongTrinhCoSoVatChat { get; set; }
    [DisplayName("STT")]

    public string? MaCongTrinh { get; set; }
    [DisplayName("Mã công trình")]
    public string? TenCongTrinh { get; set; }
    [DisplayName("Tên công trình")]
    public int? IdLoaiCongTrinh { get; set; }
    [DisplayName("Loại công trình")]
    public int? IdMucDichSuDung { get; set; }
    [DisplayName("ID Mục đích sử dụng")]

    public string? DoiTuongSuDung { get; set; }
    [DisplayName("Đối tượng sử dụng")]
    public double? DienTichSanXayDung { get; set; }
    [DisplayName("Diện tích sử dụng")]
    public double? VonBanDau { get; set; }
    [DisplayName("Vốn ban đầu")]
    public double? VonDauTu { get; set; }
    [DisplayName("Vốn đầu tư")]
    public int? IdTinhTrangCsvc { get; set; }
    [DisplayName("ID Tình trạng CSVC")]
    public int? IdHinhThucSoHuu { get; set; }
    [DisplayName("ID Hình thức sở hữu")]
    public int? CongTrinhCsvctrongNha { get; set; }
    [DisplayName("Công trình CSVC trong nhà")]
    public int? SoPhongOcongVu { get; set; }
    [DisplayName("Số phòng ở công vụ")]
    public int? SoChoOchoCanBoGiangDay { get; set; }
    [DisplayName("Số chỗ ở cho cán bộ giảng dạy")]
    public string? NamDuaVaoSuDung { get; set; }
    [DisplayName("Năm đưa vào sử dụng")]
    public virtual DmTuyChon? CongTrinhCsvctrongNhaNavigation { get; set; }
    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }

    public virtual DmLoaiCongTrinhCoSoVatChat? IdLoaiCongTrinhNavigation { get; set; }

    public virtual DmMucDichSuDungCsvc? IdMucDichSuDungNavigation { get; set; }

    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }

    public virtual ICollection<TbPhongThiNghiem> TbPhongThiNghiems { get; set; } = new List<TbPhongThiNghiem>();

    public virtual ICollection<TbPhongThucHanh> TbPhongThucHanhs { get; set; } = new List<TbPhongThucHanh>();

    public virtual ICollection<TbThietBiPtnThtren500Tr> TbThietBiPtnThtren500Trs { get; set; } = new List<TbThietBiPtnThtren500Tr>();
}