using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1._1
{
    internal class DSSV 
    {
        private int n;
        private SinhVien[] DS;

        public DSSV(int soluong)
        {
            n = soluong;
            DS = new SinhVien[n];
        }

        public void nhap()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Moi nhap thong tin cho sinh vien thu " + (i + 1) + ": ");
                DS[i] = new SinhVien();
                DS[i].nhap();
            }
        }

        public void xuat()
        {
            foreach (var sv in DS)
            {
                sv.xuat();
            }
        }

        public void TinhSoLuongSinhVien()
        {
            int soLuongKhoaLuan = DS.Count(sv => sv.lamkhoaluan());
            int soLuongChuyenDe = DS.Count(sv => sv.lamchuyende());

            Console.WriteLine("So luong sinh vien lam khoa luan tot nghiep: " + soLuongKhoaLuan);
            Console.WriteLine("So luong sinh vien lam chuyen de tot nghiep: " + soLuongChuyenDe);
        }

    }
}
