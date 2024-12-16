using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDeAnDuAnChuongTrinh
{
    public int IdDeAnDuAnChuongTrinh { get; set; }

    public string? MaDeAnDuAnChuongTrinh { get; set; }

    public string? TenDeAnDuAnChuongTrinh { get; set; }

    public string? NoiDungTomTat { get; set; }

    public string? MucTieu { get; set; }

    public DateOnly? ThoiGianHopTacTu { get; set; }

    public DateOnly? ThoiGianHopTacDen { get; set; }

    [Column(TypeName = "float")]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public double? TongKinhPhi { get; set; }

    public int? IdNguonKinhPhiDeAnDuAnChuongTrinh { get; set; }

    public virtual DmNguonKinhPhiChoDeAn? IdNguonKinhPhiDeAnDuAnChuongTrinhNavigation { get; set; }
}
