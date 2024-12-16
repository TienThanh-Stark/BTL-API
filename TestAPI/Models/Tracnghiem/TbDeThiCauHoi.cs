using System;
using System.Collections.Generic;

namespace TestAPI.Models.tracnghiem;

public partial class TbDeThiCauHoi
{
    public int Id { get; set; }

    public int? MaDeThi { get; set; }

    public int? MaCauHoi { get; set; }

    public virtual TbCauHoi? MaCauHoiNavigation { get; set; }

    public virtual TbDeThi? MaDeThiNavigation { get; set; }

    public virtual ICollection<TbKetQua> TbKetQuas { get; set; } = new List<TbKetQua>();
}
