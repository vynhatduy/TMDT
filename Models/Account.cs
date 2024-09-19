using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class Account
{
    public Guid Uid { get; set; }

    public int? RoleId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Status { get; set; }

    public bool? Shop { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();

    public virtual User UidNavigation { get; set; } = null!;

    public virtual ICollection<Ultility> IdtienIches { get; set; } = new List<Ultility>();

    public virtual ICollection<Voucher> Idvouchers { get; set; } = new List<Voucher>();
}
