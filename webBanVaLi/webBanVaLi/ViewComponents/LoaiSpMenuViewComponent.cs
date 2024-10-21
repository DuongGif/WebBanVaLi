using webBanVaLi.Models;
using Microsoft.AspNetCore.Mvc;
using webBanVaLi.Res;

namespace webBanVaLi.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly IloaispRespository _iloaispRespository;
        public LoaiSpMenuViewComponent( IloaispRespository iloaispRespository)
        {
            _iloaispRespository = iloaispRespository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _iloaispRespository.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}
