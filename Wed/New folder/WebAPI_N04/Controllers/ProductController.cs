using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using WebAPI_N04.Models;
using WebAPI_N04.Models.Products;

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
        
        [HttpGet("GetProductsByCategory/{maLoai}")]
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

        [HttpGet("GetProductsByID/{maSanPham}")]
        public Product GetProductsByID(string maSanPham)
        {          
            var sanPham = db.TDanhMucSps.Where(x => x.MaSp == maSanPham).SingleOrDefault();
            Product product = new Product {
                MaSp = sanPham.MaSp,
                TenSp = sanPham.TenSp,
                MaLoai = sanPham.MaLoai,
                AnhDaiDien = sanPham.AnhDaiDien,
                GiaNhoNhat = sanPham.GiaNhoNhat
            };
            return product;
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
        [HttpDelete("{maSanPham}")]
        public IActionResult XoaSanPham(string maSanPham)
        {
            var sanPham = db.TDanhMucSps.Where(x => x.MaSp == maSanPham).SingleOrDefault();
            db.TDanhMucSps.Remove(sanPham);
            return Ok(sanPham);
        }
        [HttpPut("{maSanPham}")]
        public IActionResult SuaSanPham(string maSanPham, TDanhMucSp tDanhMucSp)
        {
            if (maSanPham != tDanhMucSp.MaSp)
            {
                return BadRequest();
            }
            db.Entry(tDanhMucSp).State = EntityState.Modified;
            db.SaveChanges();
            return NoContent();
        }
        

    }
}
