using Microsoft.AspNetCore.Mvc;
using TMDT.Models;
using TMDT.Models.Response.User;

namespace TMDT.Controllers
{
    public class ProductController : Controller
    {
        private TMDTContext _context = new TMDTContext();
      
        public IActionResult Index(string sortBy,int? category)
        {
            var query = _context.SanPhams.AsQueryable();
            if (category.HasValue)
            {
                query = query.Where(sp => sp.Idloai == category.Value);
            }
            switch (sortBy)
            {
                case "name_asc":
                    query = query.OrderBy(sp => sp.Ten);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(sp => sp.Ten);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(sp => sp.GiaBan);
                    break;
                default:
                    query = query.OrderBy(sp => sp.Ten); // Sắp xếp mặc định
                    break;
            }
            var ds = query.Select(sp => new UserProductModel
            {
                IDSanPham=sp.IdsanPham,
                Ten=sp.Ten,
                Gia=(double)sp.GiaBan,
                HinhAnh=sp.HinhAnh,
                SoSao=0
            })
                .Take(30)
                .ToList();
            ViewBag.Categories = _context.Loais.ToList();
            return View(ds);
        }
        [HttpPost]
        public IActionResult LoadMoreProduct(int visibleCount)
        {
            var ds=_context.SanPhams.OrderBy(sp=>sp.Ten).Skip(visibleCount).Take(20).Select(sp=>new UserProductModel {
            Ten=sp.Ten,
            Gia=(double)sp.GiaBan,
            HinhAnh=sp.HinhAnh,
            IDSanPham=sp.IdsanPham,
            SoSao=0
            }).ToList();
            return PartialView("_ProductList", ds);
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            var product = _context.SanPhams.Where(x => x.IdsanPham == id).Select(sp => new UserProductDetailModel
            {
                IDSanPham = sp.IdsanPham,
                IDLoai = (int)sp.Idloai,
                TenLoai = _context.Loais.FirstOrDefault(x => x.Idloai == sp.Idloai).Ten,
                Ten = sp.Ten,
                DaBan = (int)sp.DaBan,
                GiaBan = (double)sp.GiaBan,
                HinhAnh = sp.HinhAnh,
                MoTa = sp.MoTa,
                MoTaChiTiet = sp.MoTaChiTiet,
                SoLuong = (int)sp.SoLuong,
                DanhGias = _context.DanhGia.Where(x => x.IdsanPham == id).Select(item => new UserReviewModel
                {
                    IDDanhGia = item.IddanhGia,
                    IDSanPham = item.IdsanPham,
                    ChiTiet = item.ChiTiet,
                    HinhAnh = item.HinhAnh,
                    Sao = (float)item.Sao,
                    TieuDe = item.TieuDe,
                    UID = item.Uid.ToString()
                }).ToList()
            }).FirstOrDefault();
            return View(product);
        }
    }
}
