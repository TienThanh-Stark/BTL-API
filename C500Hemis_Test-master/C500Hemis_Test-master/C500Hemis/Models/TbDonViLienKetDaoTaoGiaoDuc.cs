using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDonViLienKetDaoTaoGiaoDuc
{
    [Display(Name = "Số ID")]
    [Required(ErrorMessage = "ID Đơn Vị Liên Kết Đào Tạo Giáo Dục là bắt buộc")]
    public int IdDonViLienKetDaoTaoGiaoDuc { get; set; }
    [Display(Name = "ID Cơ Sở Giáo Dục")]
    public int? IdCoSoGiaoDuc { get; set; }
    [Display(Name = "Địa chỉ")]
    public string? DiaChi { get; set; }
    [Display(Name = "Điện Thoại")]
    public string? DienThoai { get; set; }
    [Display(Name = "Loại Liên Kết")]
    public int? IdLoaiLienKet { get; set; }
    [DisplayName("Cơ Sở Giáo Dục")]
    public virtual TbCoSoGiaoDuc? IdCoSoGiaoDucNavigation { get; set; }
    [DisplayName("Loại Liên Kết")]
    public virtual DmLoaiLienKet? IdLoaiLienKetNavigation { get; set; }
}