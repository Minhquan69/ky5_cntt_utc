using DaoMinhQuan_N05_221230966.Models;
using Microsoft.AspNetCore.Mvc;

namespace DaoMinhQuan_N05_221230966.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        QlbanNoiContext db = new QlbanNoiContext();
        List<PhanLoai> lst;
        public MenuViewComponent(QlbanNoiContext db)
        {
            this.db = db;
            lst = db.PhanLoais.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default", lst);
        }
    }
}
