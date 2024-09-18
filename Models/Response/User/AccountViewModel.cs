namespace TMDT.Models.Response.User
{
    public class AccountViewModel
    {
        public UserInfoResponse UserInfo { get; set; }
        public List<UserUltilityResponse> UserUltilities { get; set; }
    }
}