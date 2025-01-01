using BaiKtra1.Models;
using BaiKtra1.Repository;
using Microsoft.AspNetCore.Mvc;
namespace BaiKtra1.ViewComponents
{
    public class CauThuViewComponent: ViewComponent
    {
        private readonly ICauThu _cauThu;
        public CauThuViewComponent(ICauThu cauThu)
        {
            _cauThu = cauThu;
        }

        public IViewComponentResult Invoke()
        {
            var cauthu = _cauThu.GetAll().Take(7).ToList();
                return View("Default",cauthu);
        }
    }
}
