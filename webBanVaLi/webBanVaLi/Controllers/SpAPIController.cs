using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webBanVaLi.Models.SpModels;
using webBanVaLi.Models;
namespace webBanVaLi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpAPIController : ControllerBase
    {
        QLBanVaLiContext db = new QLBanVaLiContext();
        [HttpGet]
        public IEnumerable<SP> GetAllSp()
        {
            var sanpham = (from p in db.TDanhMucSps
                           select new SP
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanpham;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<SP> GetSpByList(string maloai)
        {

            var sanpham = (from p in db.TDanhMucSps
                           where p.MaLoai == maloai
                           select new SP

                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat
                           }).ToList();
            return sanpham;
        }
    }
}
