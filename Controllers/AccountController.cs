using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using TMDT.Helpers;
using TMDT.Models;
using TMDT.Models.Response.User;
using TMDT.Models.Resquest;

namespace TMDT.Controllers
{
    public class AccountController : Controller
    {
        private readonly TMDTContext _context;

        // Sử dụng Dependency Injection để lấy DbContext
        public AccountController(TMDTContext context)
        {
            _context = context;
        }

        // GET: Account/Index
        [HttpGet]
        public IActionResult Index()
        {
            // Kiểm tra Session
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")) || string.IsNullOrEmpty(HttpContext.Session.GetString("UID")))
            {
                return RedirectToAction("Login", "Account");
            }

            var UID = HttpContext.Session.GetString("UID");
            var username = HttpContext.Session.GetString("Username");

            try
            {
                var userAccount = _context.Users
                    .Where(u => u.Uid.ToString() == UID)
                    .Join(_context.Accounts, user => user.Uid, account => account.Uid, (user, account) => new { user, account })
                    .FirstOrDefault();

                if (userAccount == null)
                {
                    ViewBag.ErrorMessage = "Đã xảy ra lỗi không xác định!";
                    return View();
                }

                var userInfo = new UserInfoResponse
                {
                    Username = username,
                    HoTen = userAccount.user.HoTen,
                    DiaChi = userAccount.user.DiaChi,
                    GioiTinh = userAccount.user.GioTinh ?? false,
                    SDT = userAccount.user.Sdt,
                    NgaySinh =  (DateTime) userAccount.user.NgaySinh ,
                    Shop = userAccount.account.Shop == true ? "Có sở hữu trang bán hàng" : "Chưa tạo trang bán hàng",
                    Status = userAccount.account.Status == true ? "Hoạt động bình thường" : "Tài khoản bị hạn chế"
                };

                var ultilities = _context.Ultilities.Select(x => new UserUltilityResponse
                {
                    IDTienIch = x.IdtienIch,
                    Ten = x.Ten,
                    HinhAnh = x.HinhAnh
                }).ToList();

                var model = new AccountViewModel
                {
                    UserInfo = userInfo,
                    UserUltilities = ultilities
                };

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Đã xảy ra lỗi: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Index(UserInfoResponse userInfo, string currentPass, string newPass, string newPassAgain)
        {
            try
            {
                var username = HttpContext.Session.GetString("Username");
                var uid = HttpContext.Session.GetString("UID");

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(uid))
                {
                    return RedirectToAction("Login", "Account");
                }

                if (!string.IsNullOrEmpty(currentPass) && !string.IsNullOrEmpty(newPass) && !string.IsNullOrEmpty(newPassAgain))
                {
                    if (newPass == newPassAgain)
                    {
                        var acc = _context.Accounts.FirstOrDefault(x => x.Username == username);
                        if (acc == null)
                        {
                            ViewBag.PasswordErrorMessage = "Đã xảy ra lỗi! Vui lòng thử lại sau";
                        }
                        else
                        {
                            var currentHash = acc.Password.ToString();
                            var checkHash = HashPassword.Hasherpass(currentPass).ToString();
                            if (currentHash == checkHash)
                            {
                                acc.Password = HashPassword.Hasherpass(newPass);
                                _context.SaveChanges();
                                ViewBag.PasswordSuccessMessage = "Đã cập nhật mật khẩu";
                            }
                            else
                            {
                                ViewBag.PasswordErrorMessage = "Mật khẩu không đúng";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.PasswordErrorMessage = "Mật khẩu không trùng khớp";
                    }
                }
                else if (userInfo != null)
                {
                    var user = _context.Users.FirstOrDefault(x => x.Uid.ToString() == uid);
                    var acc = _context.Accounts.FirstOrDefault(x => x.Uid.ToString() == uid);

                    if (user == null || acc == null)
                    {
                        ViewBag.UserInfoErrorMessage = "Đã xảy ra lỗi không xác định!";
                        return View(CreateDefaultModel());
                    }

                    user.HoTen = userInfo.HoTen;
                    user.DiaChi = userInfo.DiaChi;
                    user.GioTinh = userInfo.GioiTinh;
                    user.Sdt = userInfo.SDT;
                    user.NgaySinh = userInfo.NgaySinh;

                    _context.SaveChanges();

                    ViewBag.UserInfoSuccessMessage = "Cập nhật thông tin thành công";
                }
            }
            catch (Exception e)
            {
                ViewBag.UserInfoErrorMessage = e.Message;
            }

            return View(CreateDefaultModel());
        }

        // Method to create the default model
        private AccountViewModel CreateDefaultModel()
        {
            var uid = HttpContext.Session.GetString("UID");
            if (string.IsNullOrEmpty(uid))
            {
                return new AccountViewModel();
            }

            var user = _context.Users.FirstOrDefault(x => x.Uid.ToString() == uid);
            var acc = _context.Accounts.FirstOrDefault(x => x.Uid.ToString() == uid);

            if (user == null || acc == null)
            {
                return new AccountViewModel();
            }

            var userInfoResponse = new UserInfoResponse
            {
                Username = HttpContext.Session.GetString("Username"),
                HoTen = user.HoTen,
                DiaChi = user.DiaChi,
                GioiTinh = user.GioTinh ?? false,
                SDT = user.Sdt,
                NgaySinh = (DateTime)user.NgaySinh,
                Shop = acc.Shop == true ? "Có sở hữu trang bán hàng" : "Chưa tạo trang bán hàng",
                Status = acc.Status == true ? "Hoạt động bình thường" : "Tài khoản bị hạn chế"
            };

            var ultilities = _context.Ultilities.Select(x => new UserUltilityResponse
            {
                IDTienIch = x.IdtienIch,
                Ten = x.Ten,
                HinhAnh = x.HinhAnh
            }).ToList();

            return new AccountViewModel
            {
                UserInfo = userInfoResponse,
                UserUltilities = ultilities
            };
        }

        // GET: Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("UID");
            return RedirectToAction("Login", "Account");
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                var pass = HashPassword.Hasherpass(model.Password).ToString();
                var user = _context.Accounts.FirstOrDefault(u => u.Username == model.Username && u.Password.ToString() == pass);
                if (user == null)
                {
                    ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng";
                    return View(model);
                }


                // Set session variables
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("UID", user.Uid.ToString());

                return RedirectToAction("Index", "Account");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegistModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Password != model.ConfirmPassword)
                    {
                        ViewBag.ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp nhau.";
                        return View(model);
                    }
                }
                var user = _context.Accounts.FirstOrDefault(u => u.Username == model.Username);
                if (user != null)
                {
                    ViewBag.ErrorMessage = "Tài khoản đã tồn tại";
                    return View(model);
                }
                else
                {
                    var newUser = new User
                    {
                        Uid = Guid.NewGuid(),
                        HoTen = model.HoTen,
                        Sdt = model.SDT,
                        DiaChi = model.DiaChi,
                        GioTinh = model.GioiTinh,
                        NgaySinh = model.NgaySinh
                    };
                    _context.Users.Add(newUser);
                    var newAccount = new Account
                    {
                        CreateDate = DateTime.Now,
                        Uid = newUser.Uid,
                        RoleId = 1,
                        Username = model.Username,
                        Password = HashPassword.Hasherpass(model.Password),
                        Status = true,
                        Shop = false
                    };
                    _context.Accounts.Add(newAccount);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Đã xảy ra lỗi: {ex.Message}";
                if (ex.InnerException != null)
                {
                    ViewBag.ErrorMessage += $" Inner Exception: {ex.InnerException.Message}";
                    if (ex.InnerException.InnerException != null)
                    {
                        ViewBag.ErrorMessage += $" Inner Inner Exception: {ex.InnerException.InnerException.Message}";
                    }
                }
                return View(model);
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Forgot(string username, string sdt)
        {
            try
            {
                var acc = _context.Accounts.FirstOrDefault(x => x.Username == username);
                if (acc != null)
                {
                    var user = _context.Users.FirstOrDefault(x => x.Uid == acc.Uid && x.Sdt == sdt);
                    if (user != null)
                    {
                        HttpContext.Session.SetString("UsernameForgot", acc.Username);
                        return RedirectToAction("ChangePassword", "Account");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Số điện thoại không đúng";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Tài khoàn không tồn tại";
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }
            return View();
        }
        public ActionResult ChangePassword()
        {
            var usernameForgot = HttpContext.Session.GetString("UsernameForgot");
            if (usernameForgot == null)
            {
                ViewBag.ErrorMessage = "Có lỗi trong quá trình thực hiện vui lòng thử lại";
                return RedirectToAction("Forgot", "Account");
            }
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(string NewPassword, string ConfirmPassword)
        {
            var usernameForgot = HttpContext.Session.GetString("UsernameForgot");
            if (NewPassword != ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Mật khẩu không khớp!";
                return View();
            }
            try
            {
                var pass = HashPassword.Hasherpass(NewPassword);
                var acc = _context.Accounts.FirstOrDefault(x => x.Username == usernameForgot);
                if(acc == null)
                {
                    ViewBag.ErrorMessage = "Không thể thay đổi mật khẩu lúc này!";
                }
                acc.Password = pass;
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.InnerException + e.Message + e.HResult;
                return View();
            }
            HttpContext.Session.Remove("UsernameForgot");
            ViewBag.SuccessMessage = "Mật khẩu đã được thay đổi thành công!";
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult OrderHistory()
        {
            var Username = HttpContext.Session.GetString("Username");
            var UID = HttpContext.Session.GetString("UID");
            if (Username == null || UID == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}