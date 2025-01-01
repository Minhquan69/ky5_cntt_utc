using System;

namespace Bai1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so luong xe: ");
            int soLuong = int.Parse(Console.ReadLine());

            var xeManager = new XeManager(soLuong);
            xeManager.Nhap();
            xeManager.Xuat();
        }
    }
}
