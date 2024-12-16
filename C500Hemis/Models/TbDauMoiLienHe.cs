using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDauMoiLienHe
{
    public int IdDauMoiLienHe { get; set; }

    public int? IdLoaiDauMoiLienHe { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public virtual DmDauMoiLienHe? IdLoaiDauMoiLienHeNavigation { get; set; }
}
