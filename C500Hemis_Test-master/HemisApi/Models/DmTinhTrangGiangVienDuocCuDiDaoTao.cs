using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTinhTrangGiangVienDuocCuDiDaoTao
{
    public int IdTinhTrangGiangVienDuocCuDiDaoTao { get; set; }

    public string? TinhTrangGiangVienDuocCuDiDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbGvduocCuDiDaoTao> TbGvduocCuDiDaoTaos { get; set; } = new List<TbGvduocCuDiDaoTao>();
}
