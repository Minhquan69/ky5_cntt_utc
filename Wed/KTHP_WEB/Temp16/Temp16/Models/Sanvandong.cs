using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Temp16.Models
{
    public partial class Sanvandong
    {
        [Display(Name = "Mã Sân Vận Động")]
        public string SanVanDongId { get; set; } = null!;

        [Display(Name = "Tên Sân")]
        public string? TenSan { get; set; }

        [Display(Name = "Thành Phố")]
        [Required(ErrorMessage = "Thành phố không được để trống.")]
        [RegularExpression(@"^[A-Za-z].*", ErrorMessage = "Thành phố phải bắt đầu bằng một chữ cái.")]
        public string? ThanhPho { get; set; }

        [Display(Name = "Năm Bắt Đầu")]
        public int? NamBatDau { get; set; }

        [Display(Name = "Ảnh")]
        [RegularExpression(@"^.*\.(jpg|png)$", ErrorMessage = "File ảnh chỉ được có phần mở rộng là .jpg, .png")]
        public string? Anh { get; set; }

        public virtual ICollection<Caulacbo> Caulacbos { get; set; } = new List<Caulacbo>();

        public virtual ICollection<Trandau> Trandaus { get; set; } = new List<Trandau>();
    }
}
