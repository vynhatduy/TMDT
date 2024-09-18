using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class Loai
{
    public int Idloai { get; set; }

    public string Ten { get; set; } = null!;

    public int? IddanhMuc { get; set; }

    public virtual DanhMuc? IddanhMucNavigation { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
