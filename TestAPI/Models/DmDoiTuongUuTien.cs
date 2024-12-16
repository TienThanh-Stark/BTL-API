using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmDoiTuongUuTien
{
    public int IdDoiTuongUuTien { get; set; }

    public string? DoiTuongUuTien { get; set; }

    public virtual ICollection<TbDuLieuTrungTuyen> TbDuLieuTrungTuyens { get; set; } = new List<TbDuLieuTrungTuyen>();
}
