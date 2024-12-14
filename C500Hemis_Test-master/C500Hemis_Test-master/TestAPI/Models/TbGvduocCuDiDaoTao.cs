using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbGvduocCuDiDaoTao
{
    public int IdGvduocCuDiDaoTao { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdHinhThucThamGiaGvduocCuDiDaoTao { get; set; }

    public int? IdQuocGiaDen { get; set; }

    public string? TenCoSoGiaoDucThamGiaOnn { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public int? IdTinhTrangGvduocCuDiDaoTao { get; set; }

    public int? IdNguonKinhPhiCuaGv { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmHinhThucThamGiaGvduocCuDiDaoTao? IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation { get; set; }

    public virtual DmNguonKinhPhiCuaGvduocCuDiDaoTao? IdNguonKinhPhiCuaGvNavigation { get; set; }

    public virtual DmQuocTich? IdQuocGiaDenNavigation { get; set; }

    public virtual DmTinhTrangGiangVienDuocCuDiDaoTao? IdTinhTrangGvduocCuDiDaoTaoNavigation { get; set; }
}
