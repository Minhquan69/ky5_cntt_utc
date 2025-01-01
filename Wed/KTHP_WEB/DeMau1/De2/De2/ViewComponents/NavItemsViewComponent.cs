using De2.Models;
using Microsoft.AspNetCore.Mvc;
namespace De2.ViewComponents
{
	public class NavItemsViewComponent : ViewComponent
	{
		OnlineShopContext db = new OnlineShopContext();
		List<NavItem> lst;
		public NavItemsViewComponent(OnlineShopContext db)
		{
			this.db = db;
			lst = db.NavItems.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Default", lst);
		}
	}
}
