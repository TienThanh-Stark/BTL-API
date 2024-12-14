using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmHinhThucThanhLap
{
    public int IdHinhThucThanhLap { get; set; }

    public string? HinhThucThanhLap { get; set; }

    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();
}
