using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmTuyChon
{
    public int IdTuyChon { get; set; }

    public string? TuyChon { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucHoatDongKhongLoiNhuanNavigations { get; set; } = new List<TbCoSoGiaoDuc>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucTuChuGiaoDucQpanNavigations { get; set; } = new List<TbCoSoGiaoDuc>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; } = new List<TbCongTrinhCoSoVatChat>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaoHinhThucDaoTaoTheoChuyenNguNavigations { get; set; } = new List<TbDanhSachNganhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaoNganhDaoTaoLienKetNuocNgoaiNavigations { get; set; } = new List<TbDanhSachNganhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaoUuTienDaoTaoNhanLucDuLichCnttNavigations { get; set; } = new List<TbDanhSachNganhDaoTao>();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<TbNguoiHocVayTinDung> TbNguoiHocVayTinDungs { get; set; } = new List<TbNguoiHocVayTinDung>();
}
