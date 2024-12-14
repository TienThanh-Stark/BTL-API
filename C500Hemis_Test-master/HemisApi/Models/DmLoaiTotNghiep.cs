using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiTotNghiep
{
    public int IdLoaiTotNghiep { get; set; }

    public string? LoaiTotNghiep { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhSachVanBangChungChi> TbDanhSachVanBangChungChis { get; set; } = new List<TbDanhSachVanBangChungChi>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
