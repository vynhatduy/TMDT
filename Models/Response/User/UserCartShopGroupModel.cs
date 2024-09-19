namespace TMDT.Models.Response.User
{
    public class UserCartShopGroupModel
    {
        public int IdShop { get; set; }
        public string Ten { get; set; }
        public List<UserCartDetailModel> ds { get; set; }
    }
}
