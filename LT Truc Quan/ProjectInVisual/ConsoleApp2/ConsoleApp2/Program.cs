using System;
using System.Collections.Generic;

namespace WindowsFormsApp567
{
    internal class Sach
    {
        public string Masach { get; set; }
        public string Tensach { get; set; }
        public string Tentacgia { get; set; }
        public int Soluong { get; set; }

        public Sach() { }

        public Sach(string masach, string tensach, string tentacgia, int soluong)
        {
            Masach = masach;
            Tensach = tensach;
            Tentacgia = tentacgia;
            Soluong = soluong;
        }

        public void NhapThongTin()
        {
            Console.Write("Nhap ma sach: ");
            Masach = Console.ReadLine();
            Console.Write("Nhap ten sach: ");
            Tensach = Console.ReadLine();
            Console.Write("Nhap ten tac gia: ");
            Tentacgia = Console.ReadLine();
            Console.Write("Nhap so luong: ");
            Soluong = int.Parse(Console.ReadLine());
        }

        public void XuatThongTin()
        {
            Console.WriteLine($"Ma sach: {Masach}, Ten sach: {Tensach}, Tac gia: {Tentacgia}, So luong: {Soluong}");
        }
    }

    internal class SachMoi : Sach
    {
        public string QRCode { get; set; }

        public SachMoi() : base() { }

        public SachMoi(string masach, string tensach, string tentacgia, int soluong, string qrCode)
            : base(masach, tensach, tentacgia, soluong)
        {
            QRCode = qrCode;
        }

        public new void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap ma QRCode: ");
            QRCode = Console.ReadLine();
        }

        public new void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($"QRCode: {QRCode}");
        }
    }

//    class Progra
//    {
//        static void Main(string[] args)
//        {
//            List<SachMoi> danhSachSach = new List<SachMoi>();

//            Console.Write("Nhap so luong sach muon them: ");
//            int soLuongSach = int.Parse(Console.ReadLine());

//            for (int i = 0; i < soLuongSach; i++)
//            {
//                Console.WriteLine($"Nhap thong tin sach thu {i + 1}:");
//                SachMoi sachMoi = new SachMoi();
//                sachMoi.NhapThongTin();
//                danhSachSach.Add(sachMoi);
//            }

//            Console.Write("Nhap ma qr de tim sach: ");
//            string qrcodeCanTim = Console.ReadLine();

//            SachMoi sachTimThay = danhSachSach.Find(sach => sach.QRCode == qrcodeCanTim);

//            if (sachTimThay != null)
//            {
//                Console.WriteLine("Sach con trong cua hang:");
//                sachTimThay.XuatThongTin();
//            }
//            else
//            {
//                Console.WriteLine("Khong tim thay.");
//            }

//            Console.ReadLine(); // Giữ cửa sổ console mở để xem kết quả
//        }
//    }
//}
