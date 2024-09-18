using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT.Models.Response.User
{
    public class UserProductModel
    {
        public  string IDSanPham { get; set; }
        public string HinhAnh { get; set; }
        public string Ten { get; set; }
        public float SoSao { get; set; }
        public double Gia { get; set; }

    }
}