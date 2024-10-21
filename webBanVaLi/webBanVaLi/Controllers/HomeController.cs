using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using webBanVaLi.Models;
using webBanVaLi.Models.Authentication;
using webBanVaLi.ViewModels;
using X.PagedList;

namespace webBanVaLi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QLBanVaLiContext db = new QLBanVaLiContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authentication]
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
        public IActionResult Details(TDanhMucSp dmsp)
        {
            
            return View(dmsp);
        }
        public IActionResult SanPhamTheoLoai(string maloai,int ? page) {
            
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().Where(x=>x.MaLoai==maloai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(list);
        }
        public IActionResult ChiTietSanPham(string maSp)
        {
            var sp = db.TDanhMucSps.SingleOrDefault(x=>x.MaSp==maSp);
            var anhsp = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            ViewBag.anhsp=anhsp;
            return View(sp);
        }
        public IActionResult ChiTietSp(string masp)
        {
            var sp = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == masp);
            var anhsp = db.TAnhSps.Where(x => x.MaSp == masp).ToList();
            var homeviewmodel = new HomeViewModels {danhmucsp = sp,listAnhSp = anhsp};
            return View(homeviewmodel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}