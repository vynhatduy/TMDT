namespace TMDT.Models.Resquest.User
{
    public class UserInfoResquest
    {
        public string Username { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public bool GioiTinh { get; set; }
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
    }
}