using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using webBanVaLi.Models;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace webBanVaLi.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QLBanVaLiContext db = new QLBanVaLiContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {   
            return View();
        }
        [Route("Danhmucsp")]
        public IActionResult Danhmucsp(int ? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            var listsp = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> list = new PagedList<TDanhMucSp>(listsp, pageNumber, pageSize);
            return View(list);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sp)
        {
            if(ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sp);
                db.SaveChanges();
                return RedirectToAction("DanhMucSp");
            }
            return View(sp);
        }

        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string masanpham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(), "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(), "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(), "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(), "MaDt", "TenLoai");
            var sanpham = db.TDanhMucSps.Find(masanpham);
            return View(sanpham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanpham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSp","HomeAdmin");
            }
            return View(sanpham);
        }
    }
}
