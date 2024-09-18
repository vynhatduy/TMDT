using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class DanhGium
{
    public string IddanhGia { get; set; } = null!;

    public Guid? Uid { get; set; }

    public string? IdsanPham { get; set; }

    public string? TieuDe { get; set; }

    public string? ChiTiet { get; set; }

    public double? Sao { get; set; }

    public string? HinhAnh { get; set; }

    public virtual SanPham? IdsanPhamNavigation { get; set; }

    public virtual Account? UidNavigation { get; set; }
}
