using Microsoft.AspNetCore.Mvc;
using KtraLtweb.Models;
namespace KtraLtweb.ViewComponents
{
    public class TranDauViewComponent : ViewComponent
    {
        QlgiaiBongDaContext db;
        List<Trandau> trandaus;
        public TranDauViewComponent(QlgiaiBongDaContext db)
        {
            this.db = db;
            trandaus = db.Trandaus.Take(7).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("TranDau", trandaus);
        }
    }
}
