using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDatDai
{
    public int IdDatDai { get; set; }
    [DisplayName("STT ")]

    public string? MaGiayChungNhanQuyenSoHuu { get; set; }
    [DisplayName("Mã Giấy Chứng Nhận ")]

    public double? DienTichDat { get; set; }
    [DisplayName("Diện Tích Đất ")]
    public int? IdHinhThucSoHuu { get; set; }
    [DisplayName("Hình Thức Sở Hữu  ")]
    public string? TenDonViSoHuu { get; set; }
    [DisplayName("Tên Đơn Vị Sở Hữu ")]
    public string? MinhChungQuyenSoHuuDatDai { get; set; }
    [DisplayName("Minh Chứng Quyền Sở Hữu Đất Đai ")]
    public string? MucDichSuDungDat { get; set; }
    [DisplayName("Mục Đích Sử Dụng Đất ")]
    public string? NamBatDauSuDungDat { get; set; }
    [DisplayName("Năm Bắt Đầu Sử Dụng Đất")]
    public int? ThoiGianSuDungDat { get; set; }
    [DisplayName("Thời Gian Sử Dụng Đất ")]
    public double? DienTichDatDaSuDung { get; set; }
    [DisplayName("Diện Tích Đất Đã Sử Dụng ")]

    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }
}
