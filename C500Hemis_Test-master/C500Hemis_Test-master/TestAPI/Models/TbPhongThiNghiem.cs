using System;
using System.Collections.Generic;

namespace TestAPI.Models;

public partial class TbPhongThiNghiem
{
    public int IdPhongThiNghiem { get; set; }

    public int? IdCongTrinhCsvc { get; set; }

    public int? IdLoaiPhongThiNghiem { get; set; }

    public int? IdLinhVuc { get; set; }

    public string? MucDoDapUngNhuCauNckh { get; set; }

    public string? NamDuaVaoSuDung { get; set; }

    public virtual TbCongTrinhCoSoVatChat? IdCongTrinhCsvcNavigation { get; set; }

    public virtual DmLinhVucNghienCuu? IdLinhVucNavigation { get; set; }

    public virtual DmLoaiPhongThiNghiem? IdLoaiPhongThiNghiemNavigation { get; set; }
}
