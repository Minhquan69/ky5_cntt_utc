using Microsoft.AspNetCore.Mvc;
using template1.Models;
namespace template1.ViewComponents
{
    public class CauLacBoViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        List<Caulacbo> lstcaulacbo;
        public CauLacBoViewComponent(QlgiaiBongDaContext db)
        {
            this.db = db;
            lstcaulacbo = db.Caulacbos.Take(10).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lstcaulacbo);
        }
    }
}
