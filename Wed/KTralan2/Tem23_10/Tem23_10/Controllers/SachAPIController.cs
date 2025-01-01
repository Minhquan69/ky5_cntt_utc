using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tem23_10.Models;
using Tem23_10.Models.SachModels;

namespace Tem23_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachAPIController : ControllerBase
    {

        QlthuVienContext db = new QlthuVienContext();


        [HttpGet("{tenLoaiNN}")]

        public IEnumerable<SachTheoLoaiNgonNgu> GetSachTheoLoai(string tenLoaiNN)
        {
            var lstIdMaNN = db.TNgonNgus.AsNoTracking()
                     .Where(x => x.TenNgonNgu == tenLoaiNN)
                     .Select(x => x.MaNgonNgu)
                     .ToList();

            var tsachs = (from p in db.TSaches
                          where lstIdMaNN.Contains(p.MaNgonNgu)
                          select new SachTheoLoaiNgonNgu
                          {
                              MaLoai = p.MaLoai,
                              TenSach = p.TenSach,
                              NamXb = p.NamXb,
                              MaNgonNgu = p.MaNgonNgu,
                              MaNxb = p.MaNxb,
                              FileAnh = p.FileAnh,
                              GiaTriSach = p.GiaTriSach,
                              GioiThieu = p.GioiThieu,
                              TacGia = p.TacGia,
                              TongSoTrang = p.TongSoTrang,
                              TongSoTap = p.TongSoTap,
                              LanXb = p.LanXb,
                              MaSach = p.MaSach

                          }).OrderBy(x=>x.TenSach).ToList();



            return tsachs;
        }









    }
}
