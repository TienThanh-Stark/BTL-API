using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbKiTucXa
{
    public int IdKiTucXa { get; set; }
    [DisplayName("STT")]
    public string? MaKyTucxa { get; set; }
    [DisplayName("Mã ký túc xá")]
    public int? IdHinhThucSoHuu { get; set; }
    [DisplayName("Hình thức sở hữu")]
    public int? TongChoO { get; set; }
    [DisplayName("Tổng chỗ ở")]
    public double? TongDienTich { get; set; }
    [DisplayName("Tổng diện tích")]
    public int? IdTinhTrangCsvc { get; set; }
    [DisplayName("Tình trạng Csvc")]
    public int? SoPhong { get; set; }
    [DisplayName("Số phòng")]
    public string? NamDuaVaoSuDung { get; set; }
    [DisplayName("Năm đưa vào sử dụng")]
    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }

    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }
}