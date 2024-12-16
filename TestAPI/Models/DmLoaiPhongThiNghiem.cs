using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmLoaiPhongThiNghiem
{
    public int IdLoaiPhongThiNghiem { get; set; }

    public string? LoaiPhongThiNghiem { get; set; }

    public virtual ICollection<TbPhongThiNghiem> TbPhongThiNghiems { get; set; } = new List<TbPhongThiNghiem>();
}
