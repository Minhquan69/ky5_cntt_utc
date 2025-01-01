using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
namespace WebApplication2.ViewComponents
{
    public class LoaiSachViewComponent : ViewComponent
    {
        QlthuVienContext db = new QlthuVienContext();
        List<TNhaXb> lstloaisach;
        public LoaiSachViewComponent(QlthuVienContext db)
        {
            this.db = db;
            lstloaisach = db.TNhaXbs.Take(7).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lstloaisach);
        }
    }
}