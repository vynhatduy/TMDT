namespace TMDT.Models.Resquest
{
    public class RegistModel
    {
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi{get;set;}
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}