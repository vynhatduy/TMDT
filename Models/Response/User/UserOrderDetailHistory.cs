namespace TMDT.Models.Response.User
{
    public class UserOrderDetailHistory
    {
        public string IDHoaDon { get; set; }
        public List<SanPham> DSSanPham { get; set; } = new List<SanPham>();
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
    }
}
