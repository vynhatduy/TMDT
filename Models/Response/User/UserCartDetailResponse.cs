namespace TMDT.Models.Response.User
{
    public class UserCartDetailResponse
    {
        public UserCartDetailModel CartDetailModel { get; set; }
        public UserCartShopGroupModel CartTitleShop { get; set; }
        public UserCartDetailResponse(UserCartDetailModel cartDetailModel, UserCartShopGroupModel cartTitleShop)
        {
            CartDetailModel = cartDetailModel;
            CartTitleShop = cartTitleShop;
        }
    }
}
