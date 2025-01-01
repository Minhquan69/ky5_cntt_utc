using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
namespace WebApplication3.ViewComponents
{
	public class LoaiSachViewComponent : ViewComponent
	{
		QlthuVienContext db = new QlthuVienContext();
		List<TNgonNgu> lstloaisach;
		public LoaiSachViewComponent(QlthuVienContext db)
		{
			this.db = db;
			lstloaisach = db.TNgonNgus.Take(6).ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Default", lstloaisach);
		}
	}
}