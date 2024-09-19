using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class ChiTietGioHang
{
    public int IdchiTiet { get; set; }

    public int? IdgioHang { get; set; }

    public string? IdsanPham { get; set; }

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public decimal? ThanhTien { get; set; }

    public int? Idshop { get; set; }

    public virtual GioHang? IdgioHangNavigation { get; set; }

    public virtual SanPham? IdsanPhamNavigation { get; set; }

    public virtual Shop? IdshopNavigation { get; set; }
}
