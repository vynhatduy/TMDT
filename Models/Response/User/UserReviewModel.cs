using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT.Models.Response.User
{
    public class UserReviewModel
    {
        public string IDDanhGia { get; set; }
        public string UID { get; set; }
        public string IDSanPham { get; set; }
        public string TieuDe { get; set; }
        public string ChiTiet { get; set; }
        public float Sao { get; set; }
        public string HinhAnh { get; set; }
    }
}