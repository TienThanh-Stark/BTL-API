using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmPhanLoaiCsvc
{
    public int IdPhanLoaiCsvc { get; set; }

    public string? PhanLoaiCsvc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbPhongHocGiangDuongHoiTruong> TbPhongHocGiangDuongHoiTruongs { get; set; } = new List<TbPhongHocGiangDuongHoiTruong>();
}
