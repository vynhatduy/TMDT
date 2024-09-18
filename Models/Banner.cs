using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class Banner
{
    public int Idbanner { get; set; }

    public string? Link { get; set; }

    public string? HinhAnh { get; set; }

    public bool? TrangThai { get; set; }
}
