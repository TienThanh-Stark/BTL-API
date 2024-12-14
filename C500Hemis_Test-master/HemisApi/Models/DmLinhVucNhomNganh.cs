using System;
using System.Collections.Generic;

namespace C500Hemis;

public partial class DmLinhVucNhomNganh
{
    public int IdLinhVucNhomNganh { get; set; }

    public int? IdLinhVucDaoTao { get; set; }

    public int? IdNhomNganh { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual DmLinhVucDaoTao? IdLinhVucDaoTaoNavigation { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual DmNhomNganh? IdNhomNganhNavigation { get; set; }
}
