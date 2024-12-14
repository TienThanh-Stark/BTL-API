using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class DmKetQuaKiemDinh
{
    public int IdKetQuaKiemDinh { get; set; }

    public string? KetQuaKiemDinh { get; set; }

    public virtual ICollection<TbThongTinKiemDinhCuaChuongTrinh> TbThongTinKiemDinhCuaChuongTrinhs { get; set; } = new List<TbThongTinKiemDinhCuaChuongTrinh>();

    public virtual ICollection<TbToChucKiemDinh> TbToChucKiemDinhs { get; set; } = new List<TbToChucKiemDinh>();
}
