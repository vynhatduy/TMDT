using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class HoaDon
{
    public string IdhoaDon { get; set; } = null!;

    public Guid? Uid { get; set; }

    public DateOnly? NgayTao { get; set; }

    public string? TrangThai { get; set; }

    public decimal? ThanhTien { get; set; }

    public string? Idvouchers { get; set; }

    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    public virtual Voucher? IdvouchersNavigation { get; set; }

    public virtual Account? UidNavigation { get; set; }
}
