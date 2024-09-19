using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using TMDT.Models;
using TMDT.Models.Response.User;

namespace TMDT.Controllers
{
    public class UserController : Controller
    {
        private TMDTContext _context = new TMDTContext();
        

        // GET: UserHomePage/Index
        [HttpGet]
        public ActionResult Index()
        {
            var model = new UserHomePageModel
            {
                Products = GetProducts(1),
                Banners = GetBanners(),
                Categories = GetCategories(),
                CountOfCart=GetCountOfCart()
            };
            return View(model);
        }
        //[HttpPost]
        //public ActionResult LoadMoreProduct(int currentCount)
        //{
        //    int currentVisibleCount = int.Parse(Request.Form["VisibleCount"]);
        //    currentCount += 20;
        //    var model = new UserHomePageModel
        //    {
        //        Products = GetProducts(currentVisibleCount),
        //        VisibleCount = currentVisibleCount
        //    };
        //    return PartialView("_ProductList", model);
        //}

        [HttpPost]
        public ActionResult LoadMoreProduct(int currentCount)
        {
            var model = new UserHomePageModel
            {
                Products = GetProducts(currentCount + 20) // Cộng thêm 20 sản phẩm
            };
            return PartialView("_ProductList", model);
        }
        //[HttpPost]
        //public ActionResult FilterByCategory(int? typeId)
        //{
        //    var products = GetProductsByCategory(typeId);
        //    var model = new UserHomePageModel
        //    {
        //        Products = products
        //    };
        //    return PartialView("_ProductList", model);
        //}

        [HttpPost]
        public ActionResult FilterByCategory(int? typeId)
        {
            var products = GetProductsByCategory(typeId);
            var model = new UserHomePageModel
            {
                Products = products
            };
            return PartialView("_ProductList", model);
        }
        private List<UserProductModel> GetProducts(int visibleCount)
        {
            var ds = _context.SanPhams.Take(visibleCount).Select(sp => new UserProductModel
            {
                IDSanPham = sp.IdsanPham,
                Ten = sp.Ten,
                HinhAnh = sp.HinhAnh,
                Gia = (double)sp.GiaBan,
                SoSao = 0
            }).ToList();
            return ds;
        }
        private List<UserProductModel> GetProductsByCategory(int? typeID)
        {
            var ds = _context.SanPhams.Where(x => x.Idloai == typeID).Select(x => new UserProductModel
            {
                IDSanPham = x.IdsanPham,
                Ten = x.Ten,
                HinhAnh = x.HinhAnh,
                Gia = (double)x.GiaBan,
                SoSao = 0
            }).ToList();
            return ds;
        }
        private List<UserBannerModel> GetBanners()
        {
            var ds = _context.Banners.Where(x => x.TrangThai == true)
                         .Select(b => new UserBannerModel
                         {
                             IdBanner = b.Idbanner,
                             HinhAnh = b.HinhAnh,
                             Link = b.Link
                         })
                         .ToList();
            return ds;
        }
        private List<UserCategoriesModel> GetCategories()
        {
            var ds = _context.DanhMucs.Select(x => new UserCategoriesModel
            {
                IDDanhMuc = x.IddanhMuc,
                Ten = x.Ten,
                HinhAnh = x.HinhAnh
            }).ToList();
            return ds;
        }
        private int GetCountOfCart()
        {
            try
            {
                var UID = HttpContext.Session.GetString("UID");
                if (UID == null)
                {
                    return 0;
                }
                else
                {
                    var user = _context.GioHangs.FirstOrDefault(x => x.Uid.ToString() == UID.ToString());
                    if (user == null)
                    {
                        return 0;
                    }
                    else
                    {
                        var count = 0;
                        count = _context.ChiTietGioHangs.Where(x => x.IdgioHang == user.IdgioHang).Sum(x => x.SoLuong);
                        return count;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
