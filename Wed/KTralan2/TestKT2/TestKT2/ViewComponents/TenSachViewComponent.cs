using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestKT2.Models;

namespace TestKT2.ViewComponents
{
	public class TenSachViewComponent : ViewComponent
	{
		QlthuVienContext db = new QlthuVienContext();
		public IViewComponentResult Invoke()
		{
			var tloaisach = db.TLoaiSaches.ToList();
			return View("Default", tloaisach);

		}
	}
}
