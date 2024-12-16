using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbQuaTrinhCongTacCuaCanBo
{
    public int IdQuaTrinhCongTacCuaCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public DateOnly? TuThangNam { get; set; }

    public DateOnly? DenThangNam { get; set; }

    public int? IdChucVu { get; set; }

    public int? IdChucDanhGiangVien { get; set; }

    public string? DonViCongTac { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmChucDanhGiangVien? IdChucDanhGiangVienNavigation { get; set; }

    public virtual DmChucVu? IdChucVuNavigation { get; set; }
}
