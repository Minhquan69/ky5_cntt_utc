using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1._1
{
    internal class SinhVien
    {
        public string hoten, ngaysinh;
        public float dlt, dcsdl, dtkw;


        public void nhap()
        {
            
            Console.WriteLine("Ho va ten sinh vien:");
            hoten = Console.ReadLine();
            Console.WriteLine("Ngay sinh:");
            ngaysinh = Console.ReadLine();
            Console.WriteLine("Diem lap trinh:");
            dlt = float.Parse(Console.ReadLine());
            Console.WriteLine("Diem CSDL:");
            dcsdl = float.Parse(Console.ReadLine());
            Console.WriteLine("Diem thiet ke web:");
            dtkw = float.Parse(Console.ReadLine());
        }

        public void xuat()
        {
            Console.WriteLine("Ho va ten sinh vien: " + hoten);
            Console.WriteLine("Ngay sinh: " + ngaysinh);
            Console.WriteLine("Diem lap trinh: " + dlt);
            Console.WriteLine("Diem CSDL: " + dcsdl);
            Console.WriteLine("Diem thiet ke web: " + dtkw);
            Console.WriteLine("Diem trung binh: " + dtb());
        }

        public float dtb()
        {
            return(dlt+dcsdl+dtkw)/3;
        }

        public bool lamkhoaluan()
        {
            float diemtb = dtb();
            return diemtb>=8 && dlt>=5 && dcsdl>=5 && dtkw>=5;
        }

        public bool lamchuyende()
        {
            return dlt >= 5 && dcsdl >= 5 && dtkw >= 5;
        }
    }
}
