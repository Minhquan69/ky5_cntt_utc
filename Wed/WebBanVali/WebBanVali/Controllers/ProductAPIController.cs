using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanVali.Models;
using WebBanVali.Models.ProductModels;

namespace WebBanVali.Controllers
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
        
        // POST: api/sanpham/themsanpham
        [HttpPost("themsanpham")]
        public IActionResult ThemSanPham([FromBody] TDanhMucSp sanpham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TDanhMucSps.Add(sanpham);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetProductsByCategory), new { maLoai = sanpham.MaLoai }, sanpham);
        }

        // DELETE: api/sanpham/xoasanpham/{maSanPham}
        [HttpDelete("xoasanpham/{maSanPham}")]
        public IActionResult XoaSanPham(string maSanPham)
        {
            var sanpham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSanPham);

            if (sanpham == null)
            {
                return NotFound("Không tìm thấy sản phẩm cần xóa.");
            }

            db.TDanhMucSps.Remove(sanpham);
            db.SaveChanges();

            return Ok($"Đã xóa sản phẩm: {sanpham.TenSp}");
        }
    }
}