using System;

namespace Bai1._0
{
    internal class ThiSinh
    {
        public string SBD { get; set; }
        public string HoTen { get; set; }
        public float DiemM1 { get; set; }
        public float DiemM2 { get; set; }
        public float DiemM3 { get; set; }

        public ThiSinh() { }

        public ThiSinh(string sbd, string hoTen, float m1, float m2, float m3)
        {
            SBD = sbd;
            HoTen = hoTen;
            DiemM1 = m1;
            DiemM2 = m2;
            DiemM3 = m3;
        }

        public virtual void Nhap()
        {
            Console.Write("Moi nhap so bao danh: ");
            SBD = Console.ReadLine();
            Console.Write("Moi nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Moi nhap diem mon 1: ");
            DiemM1 = float.Parse(Console.ReadLine());
            Console.Write("Moi nhap diem mon 2: ");
            DiemM2 = float.Parse(Console.ReadLine());
            Console.Write("Moi nhap diem mon 3: ");
            DiemM3 = float.Parse(Console.ReadLine());
        }

        public virtual void Xuat()
        {
            Console.WriteLine("So bao danh: "+ SBD);
            Console.WriteLine("Ho ten:"+ HoTen);
            Console.WriteLine("Diem mon 1:" + DiemM1);
            Console.WriteLine("Diem mon 2:" + DiemM2);
            Console.WriteLine("Diem mon 3:" + DiemM3);
        }

        public virtual double TinhTongDiem()
        {
            return DiemM1 + DiemM2 + DiemM3;
        }
    }
}
