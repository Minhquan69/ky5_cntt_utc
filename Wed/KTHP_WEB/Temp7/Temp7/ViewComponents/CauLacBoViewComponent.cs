using Microsoft.AspNetCore.Mvc;
using Temp7.Models;

namespace Temp7.ViewComponents
{
    public class CauLacBoViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        List<Caulacbo> lst;
        public CauLacBoViewComponent(QlgiaiBongDaContext db)
        {
            this.db = db;
            lst = db.Caulacbos.Take(6).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lst);
        }
    }
}
