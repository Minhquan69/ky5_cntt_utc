using WebBanVaLiN05.Models;

namespace WebBanVaLiN05.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(String maloaiSP);
        TLoaiSp GetLoaiSp(String maloaiSP);
        IEnumerable <TLoaiSp> GetAllLoaiSp();
    }
}
