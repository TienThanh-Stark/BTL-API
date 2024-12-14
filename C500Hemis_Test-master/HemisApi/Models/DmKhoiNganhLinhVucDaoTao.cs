using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmKhoiNganhLinhVucDaoTao
{
    public int IdKhoiNganhLinhVucNghienCuu { get; set; }

    public int? IdKhoiNganh { get; set; }

    public int? IdLinhVucDaoTao { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual TbKhoiNganhDaoTao? IdKhoiNganhNavigation { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual DmLinhVucDaoTao? IdLinhVucDaoTaoNavigation { get; set; }
}
