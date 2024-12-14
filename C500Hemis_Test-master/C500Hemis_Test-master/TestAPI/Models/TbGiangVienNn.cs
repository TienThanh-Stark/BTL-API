using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbGiangVienNn
{
    public int IdGvnn { get; set; }

    public int? IdCanBo { get; set; }

    public string? CoQuanChuQuanOnuocNgoai { get; set; }

    public int? IdNoiDungHoatDongTaiVietNam { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmNoiDungHoatDongTaiVietNam? IdNoiDungHoatDongTaiVietNamNavigation { get; set; }
}
