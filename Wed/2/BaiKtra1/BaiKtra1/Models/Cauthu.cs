using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaiKtra1.Models;

public partial class Cauthu
{
    public string CauThuId { get; set; } = null!;

    public string? HoVaTen { get; set; }

    public string? CauLacBoId { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? ViTri { get; set; }

    public string? QuocTich { get; set; }

    public string? SoAo { get; set; }

    [RegularExpression(@"^.*\.png$", ErrorMessage = "File ảnh chỉ được có phần mở rộng .png")]
    public string? Anh { get; set; }

    public virtual Caulacbo? CauLacBo { get; set; }

    public virtual ICollection<TrandauCauthu> TrandauCauthus { get; set; } = new List<TrandauCauthu>();

    public virtual ICollection<TrandauGhiban> TrandauGhibans { get; set; } = new List<TrandauGhiban>();
}
