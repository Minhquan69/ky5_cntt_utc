using Microsoft.AspNetCore.Mvc;

namespace DaoMinhQuan_N05_221230966.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public MenuViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lstMenu = new List<string> { "Menu1", "Menu2", "Menu3", "Menu4", "Menu5", "Menu6", "Menu7" };

            // Trả về View với danh sách menu
            return View("Default", lstMenu);
        }
    }
}
