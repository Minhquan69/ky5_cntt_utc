using Microsoft.AspNetCore.Mvc;
using TestKT2._1.Models;

namespace TestKT2._1.ViewComponents
{
	public class NXBViewComponent : ViewComponent
	{
		QlthuVienContext db = new QlthuVienContext();
		public IViewComponentResult Invoke()
		{
			var tnxb = db.TNhaXbs.Take(7).ToList();
			return View("Default", tnxb);

		}
	}
}
