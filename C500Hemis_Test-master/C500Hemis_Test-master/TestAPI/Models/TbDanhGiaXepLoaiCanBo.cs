using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbDanhGiaXepLoaiCanBo
{
    public int IdDanhGiaXepLoaiCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdDanhGia { get; set; }

    public DateOnly? NamDanhGia { get; set; }

    public string? NganhDuocKhenThuong { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmDanhGiaCongChucVienChuc? IdDanhGiaNavigation { get; set; }
}
