using BaiKtra1.Models;
namespace BaiKtra1.Repository
{
    public interface ICauThu
    {
        Cauthu Add(Cauthu cauthu);
        Cauthu Update(Cauthu cauthu);
        Cauthu Delete(string cauthuCauThuId);

        Cauthu GetCauThu(string cauthuCauThuId);
        IEnumerable<Cauthu> GetAll();
    }
}
