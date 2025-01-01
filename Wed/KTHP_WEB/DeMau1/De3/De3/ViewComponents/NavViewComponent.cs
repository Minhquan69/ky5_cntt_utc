using De3.Models;
using Microsoft.AspNetCore.Mvc;

namespace De3.ViewComponents
{
	public class NavViewComponent : ViewComponent
	{
		OnlineShopContext db = new OnlineShopContext();
		List<Category> lst;
		public NavViewComponent(OnlineShopContext db)
		{
			this.db = db;
			lst = db.Categories.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Default", lst);
		}
	}
}
