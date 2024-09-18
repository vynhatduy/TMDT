using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT.Models.Response.User
{
    public class UserOrderHistoryResponse
    {
        public string IDHoaDon { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
        public double ThanhTien { get; set; }
    }
}