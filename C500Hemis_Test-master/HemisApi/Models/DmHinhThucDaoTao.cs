using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmHinhThucDaoTao
{
    public int IdHinhThucDaoTao { get; set; }

    public string? HinhThucDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbHinhThucDaoTaoCuaNganh> TbHinhThucDaoTaoCuaNganhs { get; set; } = new List<TbHinhThucDaoTaoCuaNganh>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai> TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais { get; set; } = new List<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>();
}
