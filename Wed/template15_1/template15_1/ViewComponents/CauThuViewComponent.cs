using Microsoft.AspNetCore.Mvc;
using template15_1.Models;
namespace template15_1.ViewComponents
{
    public class CauThuViewComponent : ViewComponent

    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        List<Cauthu> lstcauthu;
        public CauThuViewComponent(QlgiaiBongDaContext db) 
        {
            this.db = db;
            lstcauthu = db.Cauthus.Take(7).ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lstcauthu);
        }
    }
}
