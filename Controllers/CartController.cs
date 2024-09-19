using Microsoft.AspNetCore.Mvc;
using TMDT.Models;
using TMDT.Models.Response.User;

namespace TMDT.Controllers
{
    public class CartController : Controller
    {
        private TMDTContext _context = new TMDTContext();
        public CartController(TMDTContext context)
        {
            this._context = context;
            
        }
        public IActionResult Index()
        {
           var UID = HttpContext.Session.GetString("UID");
           var IDGioHang = HttpContext.Session.GetString("IDGioHang");
            var ds = new List<UserCartShopGroupModel>();
            var cartTitle = new List<UserCartShopGroupModel>();
            if (UID != null || IDGioHang == null)
            {
                try
                {
                   var dsItem = _context.ChiTietGioHangs.Where(x =>(string) x.IdgioHang.ToString() == IDGioHang)
                         .Select(sp => new UserCartDetailModel
                         {
                             IDGioHang = (int)sp.IdgioHang,
                             Gia = (double)sp.Gia,
                             IDSanPham = sp.IdsanPham,
                             IDShop = (int)sp.Idshop,
                             SoLuong = sp.SoLuong,
                             ThanhTien = (double)sp.ThanhTien,
                             TenShop=_context.Shops.FirstOrDefault(x=>x.Idshop==sp.Idshop).TenShop
                         }).ToList();
                    ds = dsItem.GroupBy(x => new { x.IDShop, x.TenShop }).Select(x => new UserCartShopGroupModel
                    {
                        IdShop = x.Key.IDShop,
                        Ten = x.Key.TenShop,
                        ds = x.ToList()
                    }).OrderBy(g => g.Ten).ToList();
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessag = ex.Message;
                }
            }
            return View(ds);

        }

    }
}
