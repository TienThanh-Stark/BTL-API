using System;
using System.Collections.Generic;

namespace TestAPI.Models.tracnghiem;

public partial class TbThanhVien
{
    public int Id { get; set; }

    public string? TenSinhVien { get; set; }

    public string? Sdt { get; set; }

    public byte[]? Email { get; set; }

    public string? DiaChi { get; set; }

    public string? MatKhau { get; set; }

    public string? Lop { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public byte? GioiTinh { get; set; }

    public string? TaiKhoan { get; set; }

    public byte? LaGiangVien { get; set; }

    public virtual ICollection<TbKetQua> TbKetQuas { get; set; } = new List<TbKetQua>();
}
