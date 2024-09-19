using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT.Models.Response.User
{
    public class UserOrderHistory
    {
        public string IDHoaDon { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
        public double ThanhTien { get; set; }
        public string IDVoucher { get; set; }
        public int IDShop { get; set; }
        public string  TenVoucher { get; set; }
        public string TenShop { get; set; }
    }
}