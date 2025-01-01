using Microsoft.AspNetCore.Mvc;
using Temp16.Models;

namespace Temp16.ViewComponents
{
    public class TranDauViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        List<Trandau> lst;
        public TranDauViewComponent(QlgiaiBongDaContext db)
        {
            this.db = db;
            lst = db.Trandaus.Take(7).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lst);
        }
    }
}