using System;
using System.Collections.Generic;

namespace TestAPI.Models.tracnghiem;

public partial class TbMonHoc
{
    public int Id { get; set; }

    public string? TenMonHoc { get; set; }

    public virtual ICollection<TbCauHoi> TbCauHois { get; set; } = new List<TbCauHoi>();
}
