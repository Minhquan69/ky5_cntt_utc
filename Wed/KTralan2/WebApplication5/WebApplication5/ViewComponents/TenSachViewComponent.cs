using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
namespace WebApplication5.ViewComponents
{
	public class TenSachViewComponent : ViewComponent
	{
		QlthuVienContext db = new QlthuVienContext();
		List<TSach> lstloaisach;
		public TenSachViewComponent(QlthuVienContext db)
		{
			this.db = db;
			lstloaisach = db.TSaches.OrderBy(x=>x.TenSach).Take(7).ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Default", lstloaisach);
		}
	}
}