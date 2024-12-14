using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLoaiDeAnChuongTrinh
{
    public int IdLoaiDeAnChuongTrinh { get; set; }

    public string? LoaiDeAnChuongTrinh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbPhongHocGiangDuongHoiTruong> TbPhongHocGiangDuongHoiTruongs { get; set; } = new List<TbPhongHocGiangDuongHoiTruong>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbToChucHopTacDoanhNghiep> TbToChucHopTacDoanhNghieps { get; set; } = new List<TbToChucHopTacDoanhNghiep>();
}
