using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmNganhDaoTao
{
    public int IdNganhDaoTao { get; set; }

    public string? NganhDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChiTieuTuyenSinhTheoNganh> TbChiTieuTuyenSinhTheoNganhs { get; set; } = new List<TbChiTieuTuyenSinhTheoNganh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaos { get; set; } = new List<TbDanhSachNganhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHinhThucDaoTaoCuaNganh> TbHinhThucDaoTaoCuaNganhs { get; set; } = new List<TbHinhThucDaoTaoCuaNganh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh> TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs { get; set; } = new List<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNganhDungTenGiangDay> TbNganhDungTenGiangDays { get; set; } = new List<TbNganhDungTenGiangDay>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNganhGiangDayCuaCanBo> TbNganhGiangDayCuaCanBos { get; set; } = new List<TbNganhGiangDayCuaCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNhomNganhDaoTao> TbNhomNganhDaoTaos { get; set; } = new List<TbNhomNganhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; } = new List<TbQuaTrinhDaoTaoCuaCanBo>();
}
