using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.ViewComponents
{
    public class LoaiSachViewComponent : ViewComponent
    { 
        QlthuVienContext db = new QlthuVienContext();
        List<TLoaiSach> lstloaisach;
        public LoaiSachViewComponent(QlthuVienContext db)
        {
            this.db = db;
            lstloaisach = db.TLoaiSaches.Take(7).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lstloaisach);
        }
    }
}
