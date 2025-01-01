using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSSinhVien
{
    internal class DanhSach : SinhVien
    {
        private int n;
        private SinhVien[] DS;
        public void NhapDanhSach()
        {
            Console.WriteLine("Nhap so sinh vien:");
            n = int.Parse(Console.ReadLine());
            DS = new SinhVien[n];
            for (int i = 0; i < n; i++)
            {
                DS[i] = new SinhVien();
                Console.WriteLine("Nhap thong tin sinh vien thu: " + (i + 1));
                DS[i].nhap();
            }
        }
        public void InDanhSach()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Thong tin sinh vien thu :" + (i + 1));
                DS[i].inthongtin();
            }
        }
        public void FindDiem()
        {
            for (int i = 0; i < n; i++)
            {
                if ((DS[i].getDiemToan() + DS[i].getDiemHoa() + DS[i].getDiemLy()) >= 24.0)
                {
                    InDanhSach();
                }
            }
        }
        public void SapXep()
        {
            Console.WriteLine("Thong tin sinh vien sau khi sap xep: ");
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (DS[i].getMaSinhVien() < DS[j].getMaSinhVien())
                    {
                        SinhVien temp;
                        temp = DS[i];
                        DS[i] = DS[j];
                        DS[j] = temp;

                    }
                }
                


            }
            InDanhSach();
        }

    }
}
