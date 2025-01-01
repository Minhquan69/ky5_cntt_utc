using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSSinhVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
              DanhSach danhSach = new DanhSach();
            danhSach.NhapDanhSach();
            danhSach.InDanhSach();
            danhSach.FindDiem();
            danhSach.SapXep();
        }
    }
}
