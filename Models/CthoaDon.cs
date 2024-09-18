using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class CthoaDon
{
    public string IdhoaDon { get; set; } = null!;

    public string IdsanPham { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public virtual HoaDon IdhoaDonNavigation { get; set; } = null!;

    public virtual SanPham IdsanPhamNavigation { get; set; } = null!;
}
