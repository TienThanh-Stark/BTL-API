using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDuLieuTrungTuyen
{
    
    public int IdDuLieuTrungTuyen { get; set; }

    [DisplayName("Số CCCD")]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "CCCD phải có đúng 12 ký tự.")]
    public string? Cccd { get; set; }

    [DisplayName("Họ và Tên")]
    public string? HoVaTen { get; set; }

    [DisplayName("Mã Tuyển Sinh")]
    public string? MaTuyenSinh { get; set; }

    [DisplayName("Khoa Đào Tạo Trúng Tuyển")]
    public string? KhoaDaoTaoTrungTuyen { get; set; }

    public int? IdDoiTuongDauVao { get; set; }
    public int? IdDoiTuongUuTien { get; set; }
    public int? IdHinhThucTuyenSinh { get; set; }
    public int? IdKhuVuc { get; set; }

    [DisplayName("Trường THPT")]
    public string? TruongThpt { get; set; }

    [DisplayName("Tổ Hợp Môn Trúng Tuyển")]
    public string? ToHopMonTrungTuyen { get; set; }

    [DisplayName("Điểm môn 1")]
    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10.")]
    public double? DiemMon1 { get; set; }

    [DisplayName("Điểm môn 2")]
    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10.")]
    public double? DiemMon2 { get; set; }

    [DisplayName("Điểm môn 3")]
    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10.")]
    public double? DiemMon3 { get; set; }

    [DisplayName("Điểm ƯT")]
    [Range(0, 10, ErrorMessage = "Điểm từ 0 đến 10.")]
    public double? DiemUuTien { get; set; }

    [DisplayName("Tổng Điểm Xét Tuyển")]
    [Column(TypeName = "float")]
    public double? TongDiemXetTuyen { get; set; }

    [DisplayName("Số QĐ Trúng Tuyển")]
    public string? SoQuyetDinhTrungTuyen { get; set; }

    [DisplayName("Ngày Ban Hành QĐ Trúng Tuyển")]
    public DateTime? NgayBanHanhQuyetDinhTrungTuyen { get; set; }

    [DisplayName("CT Đào Tạo Đã Tốt Nghiệp Trình Độ ĐH")]
    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc { get; set; }

    [DisplayName("Ngành Đã Tốt Nghiệp Trình Độ ĐH")]
    public string? NganhDaTotNghiepTrinhDoDaiHoc { get; set; }

    [DisplayName("CT Đào Tạo đã Tốt Nghiệp Trình Độ TS")]
    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi { get; set; }

    [DisplayName("Ngành Đã Tốt Nghiệp Trình Độ TS")]
    public string? NganhDaTotNghiepTrinhDoThacSi { get; set; }

    [DisplayName("Đối Tượng Đầu Vào")]
    public virtual DmDoiTuongDauVao? IdDoiTuongDauVaoNavigation { get; set; }

    [DisplayName("Đối Tượng ƯT")]
    public virtual DmDoiTuongUuTien? IdDoiTuongUuTienNavigation { get; set; }

    [DisplayName("Hình Thức Tuyển Sinh")]
    public virtual DmHinhThucTuyenSinh? IdHinhThucTuyenSinhNavigation { get; set; }

    [DisplayName("Khu Vực")]
    public virtual DmKhuVuc? IdKhuVucNavigation { get; set; }
}
