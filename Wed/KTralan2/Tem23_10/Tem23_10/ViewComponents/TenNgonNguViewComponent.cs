using Microsoft.AspNetCore.Mvc;
using Tem23_10.Models;

namespace ttem2.ViewComponents
{
    public class TenNgonNguViewComponent : ViewComponent
    {
        QlthuVienContext db = new QlthuVienContext();
        public TenNgonNguViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

          var tenngonngus = db.TNgonNgus.Take(7).ToList();

            return View("TenNgonNgu", tenngonngus);
        }

    }
}