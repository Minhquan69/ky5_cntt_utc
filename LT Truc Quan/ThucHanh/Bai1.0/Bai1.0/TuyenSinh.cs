using System;

namespace Bai1._0
{
    internal class TuyenSinh
    {
        private int n;
        private ThiSinh[] DS;
        public int KhuVuc { get; set; }

        public TuyenSinh(int soluong)
        {
            n = soluong;
            DS = new ThiSinh[n];
        }

        public void Nhap()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Moi nhap thong tin cho thi sinh thu " + (i + 1) + ": ");
                DS[i] = new ThiSinh();
                DS[i].Nhap();
                Console.Write("Khu vuc du thi (1, 2, 3): ");
                KhuVuc = int.Parse(Console.ReadLine());
            }
        }

        public void Xuat()
        {
            foreach (var ts in DS)
            {
                ts.Xuat();
                Console.WriteLine("Khu vực: " + KhuVuc);
            }
        }

        public double TinhTongDiem(ThiSinh ts)
        {
            double diemKV;
            if (KhuVuc == 1)
            {
                diemKV = 0;
            }
            else if (KhuVuc == 2)
            {
                diemKV = 1;
            }
            else if (KhuVuc == 3)
            {
                diemKV = 2;
            }
            else
            {
                diemKV = 0;
            }
            return ts.TinhTongDiem() + diemKV;
        }


        public void XuatDanhSachTrungTuyen(double diemChuan)
        {
            Console.WriteLine("\nDanh sach trung tuyen:");
            foreach (var ts in DS)
            {
                if (TinhTongDiem(ts) >= diemChuan)
                {
                    ts.Xuat();
                }
            }
        }
    }
}
