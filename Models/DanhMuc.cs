using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class DanhMuc
{
    public int IddanhMuc { get; set; }

    public string Ten { get; set; } = null!;

    public string? HinhAnh { get; set; }

    public virtual ICollection<Loai> Loais { get; set; } = new List<Loai>();
}
