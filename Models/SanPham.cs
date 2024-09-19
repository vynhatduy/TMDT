using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class SanPham
{
    public string IdsanPham { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public string Ten { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? MoTaChiTiet { get; set; }

    public int? Idloai { get; set; }

    public int? Idshop { get; set; }

    public double? GiaBan { get; set; }

    public int? SoLuong { get; set; }

    public int? DaBan { get; set; }

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

    public virtual ICollection<CthoaDon> CthoaDons { get; set; } = new List<CthoaDon>();

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual Loai? IdloaiNavigation { get; set; }

    public virtual Shop? IdshopNavigation { get; set; }
}
