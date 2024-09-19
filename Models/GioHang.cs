using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class GioHang
{
    public int IdgioHang { get; set; }

    public Guid? Uid { get; set; }

    public DateTime NgayTao { get; set; }

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

    public virtual Account? UidNavigation { get; set; }
}
