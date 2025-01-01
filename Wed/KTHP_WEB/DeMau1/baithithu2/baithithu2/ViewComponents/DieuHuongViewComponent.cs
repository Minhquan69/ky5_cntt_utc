using Microsoft.AspNetCore.Mvc;
using baithithu2.Models;
namespace baithithu2.ViewComponents
{
	public class DieuHuongViewComponent:ViewComponent
	{
		OnlineShopContext db = new OnlineShopContext();
		List<NavItem> s;
		public DieuHuongViewComponent()
		{
			s = db.NavItems.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Default",s);
		}
	}
}
