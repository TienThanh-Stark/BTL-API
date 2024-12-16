using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbChucDanhKhoaHocCuaCanBo
{
    public int IdChucDanhKhoaHocCuaCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdChucDanhKhoaHoc { get; set; }

    public int? IdThamQuyenQuyetDinh { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayQuyetDinh { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmChucDanhKhoaHoc? IdChucDanhKhoaHocNavigation { get; set; }

    public virtual DmLoaiQuyetDinh? IdThamQuyenQuyetDinhNavigation { get; set; }
}
