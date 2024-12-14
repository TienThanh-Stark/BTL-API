using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmPhuongThucKhenThuong
{
    public int IdPhuongThucKhenThuong { get; set; }

    public string? PhuongThucKhenThuong { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo> TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd> TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>();
}
