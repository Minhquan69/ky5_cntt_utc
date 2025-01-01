using Microsoft.AspNetCore.Mvc;
using WebAPI_N05.Models.Products;
using WebAPI_N05.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using WebAPI_N05.Models;
using WebAPI_N05.Models.Products;

namespace WebAPI_N04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            IList<Product> lstproducts = new List<Product>();
            var sanPhams = db.TDanhMucSps.OrderBy(x => x.TenSp).ToList();
            foreach (var sanPham in sanPhams)
            {
                lstproducts.Add(new Product
                {
                    MaSp = sanPham.MaSp,
                    TenSp = sanPham.TenSp,
                    MaLoai = sanPham.MaLoai,
                    AnhDaiDien = sanPham.AnhDaiDien,
                    GiaNhoNhat = sanPham.GiaNhoNhat
                });
            }
            return lstproducts;
        }
        [HttpGet("{maLoai}")]
        public IEnumerable<Product> GetProductsByCategory(string maLoai)
        {
            IList<Product> lstproducts = new List<Product>();
            var sanPhams = db.TDanhMucSps.Where(x => x.MaLoai == maLoai).OrderBy(x => x.TenSp).ToList();
            foreach (var sanPham in sanPhams)
            {
                lstproducts.Add(new Product
                {
                    MaSp = sanPham.MaSp,
                    TenSp = sanPham.TenSp,
                    MaLoai = sanPham.MaLoai,
                    AnhDaiDien = sanPham.AnhDaiDien,
                    GiaNhoNhat = sanPham.GiaNhoNhat
                });
            }
            return lstproducts;
        }
        [HttpPost]
        public IActionResult ThemSanPham([FromBody] TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(sanPham);
                db.SaveChanges();
            }
            return Ok(sanPham);
        }
    }
}