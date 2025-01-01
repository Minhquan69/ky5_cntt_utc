using WebBanVaLiN05.Models;
using Microsoft.AspNetCore.Mvc;
using WebBanVaLiN05.Repository;

namespace WebBanVaLiN05.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;

        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }

        public IViewComponentResult Invoke()
        { 
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x=>x.Loai);
            return View(loaisp);
        }
    }
}
