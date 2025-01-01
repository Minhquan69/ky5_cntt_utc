using ThucHanhweb.Models;

namespace ThucHanhweb.Repositoy
{
    public interface iLoaiSanPhamRepository
    {
        TLoaiSP Add(TLoaiSp loaisp);
        TLoaiSP Update(string maloai);
        TLoaiSP Delete(sting maloai);
        TLoaiSP GetLoaiSp(string Maloai);
        IEnumerable<TLoaiSp> GetAllLoaiSp();

    }
}
