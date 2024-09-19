using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TMDT.Models.Response.User
{
    public class UserHomePageModel
    {
        public List<UserProductModel> Products { get; set; }
        public List<UserBannerModel> Banners { get; set; }
        public List<UserCategoriesModel> Categories { get; set; }
        public int CountOfCart { get; set; }
        public int VisibleCount { get; set; }

        public UserHomePageModel()
        {
            
            Products = new List<UserProductModel>();
            Banners = new List<UserBannerModel>();
            Categories = new List<UserCategoriesModel>();
            VisibleCount = 8;
            CountOfCart = 0;
        }
    }
}