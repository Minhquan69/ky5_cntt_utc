using Microsoft.AspNetCore.Mvc;
using template10.Models;
namespace template10.ViewComponents
{
	public class CauThuViewComponent : ViewComponent
	{
		QliGiaiBongDaContext db = new QliGiaiBongDaContext();
		List<Cauthu> lstcauthu;
		public CauThuViewComponent() 
		{
			this.db = db;
			lstcauthu = db.Cauthus.Take(7).OrderBy(x => x.HoVaTen).ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Default", lstcauthu);
		}
	}
}
