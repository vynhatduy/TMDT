namespace TMDT.Models.Resquest
{
    public class ChangePasswordModel
    {
        public string CurentPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
    }
}