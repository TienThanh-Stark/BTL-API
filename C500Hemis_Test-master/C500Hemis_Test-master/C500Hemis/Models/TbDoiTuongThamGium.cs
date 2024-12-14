using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDoiTuongThamGium
{
    public int IdDoiTuongThamGia { get; set; }

    public int? IdLoaiThamGia { get; set; }

    public string? MaLoaiThamGia { get; set; }

    public int? IdNguoi { get; set; }

    public int? IdVaiTro { get; set; }

    public int? IdPhanLoai { get; set; }

    public virtual DmLoaiThamGium? IdLoaiThamGiaNavigation { get; set; }

    public virtual TbNguoi? IdNguoiNavigation { get; set; }

    public virtual DmPhanLoaiDoiNguNguoiHoc? IdPhanLoaiNavigation { get; set; }

    public virtual DmVaiTroThamGium? IdVaiTroNavigation { get; set; }
}
