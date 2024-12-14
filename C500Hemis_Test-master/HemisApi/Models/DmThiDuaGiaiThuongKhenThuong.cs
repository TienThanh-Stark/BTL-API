using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmThiDuaGiaiThuongKhenThuong
{
    public int IdThiDuaGiaiThuongKhenThuong { get; set; }

    public string? ThiDuaGiaiThuongKhenThuong { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo> TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd? TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>();
}
