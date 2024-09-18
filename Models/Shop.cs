using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class Shop
{
    public int Idshop { get; set; }

    public Guid? Uid { get; set; }

    public string TenShop { get; set; } = null!;

    public string? Mota { get; set; }

    public string? DiaChi { get; set; }

    public double? Sao { get; set; }

    public DateOnly? CreateDate { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();

    public virtual Account? UidNavigation { get; set; }
}
