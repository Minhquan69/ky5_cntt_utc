using Microsoft.AspNetCore.Mvc;
using Temp17.Models;

namespace Temp17.ViewComponents
{
    public class CauLacBoViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        List<Caulacbo> lst;
        public CauLacBoViewComponent(QlgiaiBongDaContext db)
        {
            this.db = db;
            lst = db.Caulacbos.Take(7).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lst);
        }
    }
}