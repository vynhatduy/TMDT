using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class Voucher
{
    public string Idvouchers { get; set; } = null!;

    public string? Ten { get; set; }

    public string? HinhAnh { get; set; }

    public decimal? Giam { get; set; }

    public string? DonViTinh { get; set; }

    public string? PhamViApDung { get; set; }

    public int? SoLuong { get; set; }

    public int? SoLuongConlai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<Account> Uids { get; set; } = new List<Account>();
}
