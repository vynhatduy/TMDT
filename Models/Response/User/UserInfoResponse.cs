using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMDT.Models.Response.User
{
    public class UserInfoResponse
    {
        public string Username { get; set; }
        public string HoTen { get; set; }
        public string  DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Shop { get; set; }
        public string Status { get; set; }

    }
}