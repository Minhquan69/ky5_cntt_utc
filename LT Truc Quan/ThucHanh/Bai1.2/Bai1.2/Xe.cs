using System;

namespace Bai1._2
{
    internal class XeManager
    {
        private QLXe[] dsXe;

        public XeManager(int soLuong)
        {
            dsXe = new QLXe[soLuong];
        }

        public void Nhap()
        {
            for (int i = 0; i < dsXe.Length; i++)
            {
                Console.WriteLine($"Nhap thong tin cho xe thu {i + 1}: ");
                dsXe[i] = new QLXe();
                dsXe[i].Nhap();
            }
        }

        public void Xuat()
        {
            foreach (var xe in dsXe)
            {
                xe.xuat();
            }
        }
    }
}
