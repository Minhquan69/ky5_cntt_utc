using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeMau.Models;

public partial class HangHoa
{
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    public string TenHang { get; set; } = null!;

    [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000.")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^.*\.(jpg|png|gif|tiff)$", ErrorMessage = "File ảnh chỉ được có phần mở rộng là .jpg, .png, .gif hoặc .tiff.")]
    public string? Anh { get; set; }

    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
