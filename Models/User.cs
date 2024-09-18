using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class User
{
    public Guid Uid { get; set; }

    public string HoTen { get; set; } = null!;

    public bool? GioTinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public DateTime? NgaySinh { get; set; }

    public virtual Account? Account { get; set; }
}
