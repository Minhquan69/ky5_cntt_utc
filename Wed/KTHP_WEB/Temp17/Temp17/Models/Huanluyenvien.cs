using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Temp17.Models;

public partial class Huanluyenvien
{
    public string HuanLuyenVienId { get; set; } = null!;

    public string? TenHlv { get; set; }

    public int? NamSinh { get; set; }

    public string? QuocTich { get; set; }
    [RegularExpression(@"^.*\.jpg$", ErrorMessage = "File ảnh chỉ được có phần mở rộng là .jpg")]
    public string? Anh { get; set; }

    public virtual ICollection<Caulacbo> Caulacbos { get; set; } = new List<Caulacbo>();
}
