using Microsoft.AspNetCore.Mvc;
using template9.Models;
namespace template9.ViewComponents
{
    public class TranDauViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        List<Trandau> lsttrandau;
        public TranDauViewComponent(QlgiaiBongDaContext db)
        {
            this.db = db;
            lsttrandau = db.Trandaus.Take(8).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lsttrandau);
        }
    }
}
