using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbGiaoVienQpan
{
    public int IdGiaoVienQpan { get; set; }

    public int? IdCanBo { get; set; }

    public DateOnly? NamBatDauBietPhai { get; set; }

    public DateOnly? SoNamBietPhai { get; set; }

    public int? IdLoaiGiangVienQp { get; set; }

    public string? DaoTaoGdqpan { get; set; }

    public int? IdQuanHam { get; set; }

    public string? SoTruongCongTac { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmLoaiGiangVienQuocPhong? IdLoaiGiangVienQpNavigation { get; set; }

    public virtual DmQuanHam? IdQuanHamNavigation { get; set; }
}
