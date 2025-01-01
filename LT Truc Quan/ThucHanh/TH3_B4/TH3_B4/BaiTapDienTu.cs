using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH3_B4
{
    public class BaiTapDienTu
    {
        private string debai { get; set; }
        private string dapan { get; set; }
        private List<string> dapantungcau { get; set; }

        public BaiTapDienTu() { Dapantungcau = new List<string>(); }

        public BaiTapDienTu(string debai, string dapan)
        {
            this.Debai = debai;
            this.Dapan = dapan;
        }

        public BaiTapDienTu(string debai, string dapan, List<string> dapantungcau)
        {
            this.Debai1 = debai;
            this.Dapan1 = dapan;
            this.Dapantungcau = dapantungcau;
        }

        public string Debai { get => debai; set => debai = value; }
        public string Dapan { get => dapan; set => dapan = value; }
        public string Debai1 { get => Debai1; set => Debai1 = value; }
        public string Dapan1 { get => Dapan1; set => Dapan1 = value; }
        public List<string> Dapantungcau { get => dapantungcau; set => dapantungcau = value; }
    }



}
