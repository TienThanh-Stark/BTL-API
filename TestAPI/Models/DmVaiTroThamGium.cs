using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmVaiTroThamGium
{
    public int IdVaiTroThamGia { get; set; }

    public string? VaiTroThamGia { get; set; }

    public virtual ICollection<TbDoiTuongThamGium> TbDoiTuongThamGia { get; set; } = new List<TbDoiTuongThamGium>();

    public virtual ICollection<TbThanhPhanThamGiaDoanCongTac> TbThanhPhanThamGiaDoanCongTacs { get; set; } = new List<TbThanhPhanThamGiaDoanCongTac>();
}
