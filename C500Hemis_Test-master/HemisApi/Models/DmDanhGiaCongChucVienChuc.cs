using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmDanhGiaCongChucVienChuc
{
    public int IdDanhGiaCongChucVienChuc { get; set; }

    public string? DanhGiaCongChucVienChuc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhGiaXepLoaiCanBo> TbDanhGiaXepLoaiCanBos { get; set; } = new List<TbDanhGiaXepLoaiCanBo>();
}
