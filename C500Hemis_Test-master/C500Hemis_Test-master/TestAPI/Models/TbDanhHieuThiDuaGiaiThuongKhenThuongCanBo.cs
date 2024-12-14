using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo
{
    public int IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }

    public int? IdThiDuaGiaiThuongKhenThuong { get; set; }

    public int? SoQuyetDinh { get; set; }

    public int? IdPhuongThucKhenThuong { get; set; }

    public DateOnly? NamKhenThuong { get; set; }

    public int? IdCapKhenThuong { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmCapKhenThuong? IdCapKhenThuongNavigation { get; set; }

    public virtual DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }

    public virtual DmPhuongThucKhenThuong? IdPhuongThucKhenThuongNavigation { get; set; }

    public virtual DmThiDuaGiaiThuongKhenThuong? IdThiDuaGiaiThuongKhenThuongNavigation { get; set; }
}
