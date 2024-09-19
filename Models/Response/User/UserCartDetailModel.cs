namespace TMDT.Models.Response.User
{
    public class UserCartDetailModel
    {
        public int IDGioHang { get; set; }
        public int IDShop { get; set; }
        public string IDSanPham { get; set; }
        public int SoLuong { get; set; }
        public double  Gia { get; set; }
        public double ThanhTien { get; set; }
        public string TenShop { get; set; }
    }
}
