using System;
using System.Collections.Generic;

namespace TMDT.Models;

public partial class Ultility
{
    public int IdtienIch { get; set; }

    public string Ten { get; set; } = null!;

    public bool? TrangThai { get; set; }

    public string? PhamViApDung { get; set; }

    public string? HinhAnh { get; set; }

    public virtual ICollection<Account> Uids { get; set; } = new List<Account>();
}
