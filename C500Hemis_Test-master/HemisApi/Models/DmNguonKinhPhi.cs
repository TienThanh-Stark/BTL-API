using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmNguonKinhPhi
{
    public int IdNguonKinhPhi { get; set; }

    public string? NguonKinhPhi { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHoatDongBaoVeMoiTruong> TbHoatDongBaoVeMoiTruongs { get; set; } = new List<TbHoatDongBaoVeMoiTruong>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHoiThaoHoiNghi> TbHoiThaoHoiNghis { get; set; } = new List<TbHoiThaoHoiNghi>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo> TbKhoaBoiDuongTapHuanThamGiaCuaCanBos { get; set; } = new List<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; } = new List<TbNhiemVuKhcn>();
}
