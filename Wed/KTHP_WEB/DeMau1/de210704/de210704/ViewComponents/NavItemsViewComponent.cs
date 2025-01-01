using de210704.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using de210704.Models;

namespace ttem2.ViewComponents
{
    public class NavItemsViewComponent : ViewComponent
    {
        
        OnlineShopContext db = new OnlineShopContext();
        public NavItemsViewComponent()
        {

        }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var lst = db.NavItems.ToList();

			return View("Default", lst);
		}

	}
}