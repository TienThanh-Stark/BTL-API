using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmHinhThucHopTac
{
    public int IdHinhThucHopTac { get; set; }

    public string? HinhThucHopTac { get; set; }

    public virtual ICollection<TbThongTinHopTac> TbThongTinHopTacs { get; set; } = new List<TbThongTinHopTac>();
}
