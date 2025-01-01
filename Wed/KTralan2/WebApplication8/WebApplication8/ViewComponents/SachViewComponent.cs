using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;
namespace WebApplication8.ViewComponents
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