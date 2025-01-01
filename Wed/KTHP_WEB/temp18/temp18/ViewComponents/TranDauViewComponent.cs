using Microsoft.AspNetCore.Mvc;
using temp18.Models;

namespace temp18.ViewComponents
{
	public class TranDauViewComponent : ViewComponent
	{
		QliGiaiBongDaContext db = new QliGiaiBongDaContext();
		List<Trandau> lsttrandau;
		public TranDauViewComponent(QliGiaiBongDaContext db)
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
