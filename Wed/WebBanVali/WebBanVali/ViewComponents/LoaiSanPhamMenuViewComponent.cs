using Microsoft.AspNetCore.Mvc;
using WebBanVali.Models;
using WebBanVali.Respository;
namespace WebBanVali.ViewComponents
{
    public class LoaiSanPhamMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSanPhamRespsitory _loaiSp;

        public LoaiSanPhamMenuViewComponent(ILoaiSanPhamRespsitory l)
        {
            _loaiSp = l;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaisp);
        }
    }
}

