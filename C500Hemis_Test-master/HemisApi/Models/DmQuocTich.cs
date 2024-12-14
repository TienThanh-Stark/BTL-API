using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmQuocTich
{
    public int IdQuocTich { get; set; }

    public string? TenNuoc { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDoanCongTac> TbDoanCongTacs { get; set; } = new List<TbDoanCongTac>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbGvduocCuDiDaoTao> TbGvduocCuDiDaoTaos { get; set; } = new List<TbGvduocCuDiDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; } = new List<TbQuaTrinhDaoTaoCuaCanBo>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbThietBiPtnThtren500Tr> TbThietBiPtnThtren500Trs { get; set; } = new List<TbThietBiPtnThtren500Tr>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbToChucHopTacQuocTe> TbToChucHopTacQuocTes { get; set; } = new List<TbToChucHopTacQuocTe>();
}
