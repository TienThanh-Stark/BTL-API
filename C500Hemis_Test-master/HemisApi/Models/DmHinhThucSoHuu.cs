using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHinhThucSoHuu
{
    public int IdHinhThucSoHuu { get; set; }

    public string? HinhThucSoHuu { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; } = new List<TbCongTrinhCoSoVatChat>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDatDai> TbDatDais { get; set; } = new List<TbDatDai>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbKiTucXa> TbKiTucXas { get; set; } = new List<TbKiTucXa>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbPhongHocGiangDuongHoiTruong> TbPhongHocGiangDuongHoiTruongs { get; set; } = new List<TbPhongHocGiangDuongHoiTruong>();
}
