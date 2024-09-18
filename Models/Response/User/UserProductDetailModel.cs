using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT.Models.Response.User
{
    public class UserProductDetailModel
    {
        public string IDSanPham { get; set; }
        public string HinhAnh  { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string MoTaChiTiet { get; set; }
        public int IDLoai { get; set; }
        public string TenLoai { get; set; }
        public double GiaBan { get; set; }
        public int SoLuong { get; set; }
        public int DaBan { get; set; }
        public List<UserReviewModel> DanhGias { get; set; }
    }
}