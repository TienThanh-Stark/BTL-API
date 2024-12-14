using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiHinhDaoTao
{
    public int IdLoaiHinhDaoTao { get; set; }

    public string? LoaiHinhDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChiTieuTuyenSinhTheoNganh> TbChiTieuTuyenSinhTheoNganhs { get; set; } = new List<TbChiTieuTuyenSinhTheoNganh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh> TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs { get; set; } = new List<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; } = new List<TbQuaTrinhDaoTaoCuaCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
