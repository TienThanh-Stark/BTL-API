using System;
using System.Collections.Generic;

namespace TestAPI.Models.tracnghiem;

public partial class TbCauHoi
{
    public int Id { get; set; }

    public string? CauHoi { get; set; }

    public string? DapAnA { get; set; }

    public string? DapAnB { get; set; }

    public string? DapAnC { get; set; }

    public string? DapAnD { get; set; }

    public string? DapAn { get; set; }

    public string? GhiChu { get; set; }

    public int? MaMonHoc { get; set; }

    public int? MaMucDo { get; set; }

    public virtual TbMonHoc? MaMonHocNavigation { get; set; }

    public virtual TbMucDo? MaMucDoNavigation { get; set; }

    public virtual ICollection<TbDeThiCauHoi> TbDeThiCauHois { get; set; } = new List<TbDeThiCauHoi>();
}
