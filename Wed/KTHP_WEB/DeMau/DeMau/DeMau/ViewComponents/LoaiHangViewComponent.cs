using Microsoft.AspNetCore.Mvc;
using DeMau.Models;
namespace DeMau.ViewComponents
{
	public class LoaiHangViewComponent : ViewComponent
	{
		QlhangHoaContext db = new QlhangHoaContext();
		List<LoaiHang> lstloai;
		public LoaiHangViewComponent(QlhangHoaContext db)
		{
			this.db = db;
			lstloai = db.LoaiHangs.ToList();
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Default", lstloai);
		}
	}
}