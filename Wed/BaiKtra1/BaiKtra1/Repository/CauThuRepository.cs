using BaiKtra1.Models;

namespace BaiKtra1.Repository
{
    public class CauThuRepository : ICauThu
    {
        private readonly QlgiaiBongDaContext _context;
        public CauThuRepository(QlgiaiBongDaContext context)
        {
            _context = context;
        }
        public Cauthu Add(Cauthu cauthu)
        {
            throw new NotImplementedException();
        }

        public Cauthu Delete(string cauthuCauThuId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cauthu> GetAll()
        {
            return _context.Cauthus;
        }

        public Cauthu GetCauThu(string cauthuCauThuId)
        {
            throw new NotImplementedException();
        }

        public Cauthu Update(Cauthu cauthu)
        {
            throw new NotImplementedException();
        }
    }
}
