using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHinhThucThamGiaGvduocCuDiDaoTao
{
    public int IdHinhThucThamGiaGvduocCuDiDaoTao { get; set; }

    public string? HinhThucThamGiaGvduocCuDiDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbGvduocCuDiDaoTao> TbGvduocCuDiDaoTaos { get; set; } = new List<TbGvduocCuDiDaoTao>();
}
