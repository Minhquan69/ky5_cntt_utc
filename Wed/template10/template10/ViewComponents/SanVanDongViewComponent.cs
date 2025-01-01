using Microsoft.AspNetCore.Mvc;

using template10.Models;
namespace template10.ViewComponents
{
    public class SanVanDongViewComponent :ViewComponent
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        List<Sanvandong> lstsanvandong;
        public SanVanDongViewComponent(QlgiaiBongDaContext db)
        {
            this.db = db;
            lstsanvandong = db.Sanvandongs.Take(8).ToList();
        }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Default", lstsanvandong);
		}
	}
}
