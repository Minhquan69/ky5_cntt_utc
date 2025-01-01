using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    using System;

    public class PhanSo
    {
        private int TuSo;
        private int MauSo;

        public PhanSo()
        {
            TuSo = 0;
            MauSo = 1;
        }

        public PhanSo(int tuSo, int mauSo)
        {
            if (mauSo == 0)
            {
                throw new ArgumentException("Mẫu số không thể bằng 0");
            }
            TuSo = tuSo;
            MauSo = mauSo;
        }

        public void NhapPhanSo()
        {
            Console.Write("Nhập tử số: ");
            TuSo = int.Parse(Console.ReadLine());

            do
            {
                Console.Write("Nhập mẫu số (khác 0): ");
                MauSo = int.Parse(Console.ReadLine());
                if (MauSo == 0)
                {
                    Console.WriteLine("Mẫu số không thể bằng 0, vui lòng nhập lại.");
                }
            } while (MauSo == 0);
        }

        public void InPhanSo()
        {
            if (MauSo == 1)
            {
                Console.WriteLine($"{TuSo}");
            }
            else
            {
                Console.WriteLine($"{TuSo}/{MauSo}");
            }
        }

        public void RutGon()
        {
            int ucln = UCLN(TuSo, MauSo);
            TuSo /= ucln;
            MauSo /= ucln;
        }

        private int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a); // UCLN luôn là số dương
        }

        public static PhanSo operator +(PhanSo ps1, PhanSo ps2)
        {
            int tu = ps1.TuSo * ps2.MauSo + ps2.TuSo * ps1.MauSo;
            int mau = ps1.MauSo * ps2.MauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }

        public static PhanSo operator -(PhanSo ps1, PhanSo ps2)
        {
            int tu = ps1.TuSo * ps2.MauSo - ps2.TuSo * ps1.MauSo;
            int mau = ps1.MauSo * ps2.MauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }

        public static PhanSo operator *(PhanSo ps1, PhanSo ps2)
        {
            int tu = ps1.TuSo * ps2.TuSo;
            int mau = ps1.MauSo * ps2.MauSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }

        public static PhanSo operator /(PhanSo ps1, PhanSo ps2)
        {
            if (ps2.TuSo == 0)
            {
                throw new DivideByZeroException("Không thể chia cho phân số có tử số bằng 0");
            }

            int tu = ps1.TuSo * ps2.MauSo;
            int mau = ps1.MauSo * ps2.TuSo;
            PhanSo ketQua = new PhanSo(tu, mau);
            ketQua.RutGon();
            return ketQua;
        }
    }

    class kl
    {
        static void Main(string[] args)
        {
            PhanSo ps1 = new PhanSo();
            PhanSo ps2 = new PhanSo();

            Console.WriteLine("Nhập phân số thứ nhất:");
            ps1.NhapPhanSo();

            Console.WriteLine("Nhập phân số thứ hai:");
            ps2.NhapPhanSo();

            PhanSo tong = ps1 + ps2;
            PhanSo hieu = ps1 - ps2;
            PhanSo tich = ps1 * ps2;
            PhanSo thuong = ps1 / ps2;

            Console.WriteLine("Phân số thứ nhất:");
            ps1.InPhanSo();

            Console.WriteLine("Phân số thứ hai:");
            ps2.InPhanSo();

            Console.WriteLine("Tổng hai phân số:");
            tong.InPhanSo();

            Console.WriteLine("Hiệu hai phân số:");
            hieu.InPhanSo();

            Console.WriteLine("Tích hai phân số:");
            tich.InPhanSo();

            Console.WriteLine("Thương hai phân số:");
            thuong.InPhanSo();
        }
    }

}
