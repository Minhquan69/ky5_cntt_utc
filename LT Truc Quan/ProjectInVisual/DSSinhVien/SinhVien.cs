using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSSinhVien
{
    internal class SinhVien
    {
        private int MaSinhVien;
        private string HoTen;
        private double DiemToan,DiemLy,DiemHoa;
        public void nhap()
        {
            Console.WriteLine("Nhap ma sinh vien:");
            MaSinhVien = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap ho ten");
            HoTen = Console.ReadLine();
            Console.WriteLine("Nhap diem toan:");
            DiemToan = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap diem ly:");
            DiemLy = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap diem hoa:");
            DiemHoa = double.Parse(Console.ReadLine());
        }
        public void inthongtin()
        {
            Console.WriteLine("Ma Sinh Vien:{0} ", MaSinhVien);
            Console.WriteLine("HoTen: " + HoTen);
            Console.WriteLine("Diem Toan, Ly, Hoa: {0}, {1}, {2}", DiemToan,DiemLy,DiemHoa);
        }
       public double getDiemToan()
        { return DiemToan; }
        public double getDiemLy()
        { return DiemLy; }

        public double getDiemHoa()
        { return DiemHoa; }
        public int getMaSinhVien()
        {
            return MaSinhVien;
        }

    }
}





