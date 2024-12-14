using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmHinhThucTuyenSinh
{
    public int IdHinhThucTuyenSinh { get; set; }

    public string? HinhThucTuyenSinh { get; set; }

    public virtual ICollection<TbDuLieuTrungTuyen> TbDuLieuTrungTuyens { get; set; } = new List<TbDuLieuTrungTuyen>();
}
