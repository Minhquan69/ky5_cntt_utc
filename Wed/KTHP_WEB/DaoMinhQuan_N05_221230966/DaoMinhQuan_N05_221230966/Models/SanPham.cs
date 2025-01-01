using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DaoMinhQuan_N05_221230966.Models;

public partial class SanPham
{
    [Display(Name = "Mã của sản phẩm")]
    public string MaSanPham { get; set; } = null!;

    [Display(Name = "Tên của sản phẩm")]
    [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
    [RegularExpression(@"^[A-Za-z].*", ErrorMessage = "Tên sản phẩm phải bắt đầu bằng một chữ cái.")]
    public string TenSanPham { get; set; } = null!;

    [Display(Name = "Loại sản phẩm chính")]
    public string? MaPhanLoai { get; set; }

    public long? GiaNhap { get; set; }
    [Display(Name = "Giá bán nhỏ nhất")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Chỉ được phép nhập chữ số.")]
    public long? DonGiaBanNhoNhat { get; set; }


    [Display(Name = "Giá bán lớn nhất")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Chỉ được phép nhập chữ số.")]
    public long? DonGiaBanLonNhat { get; set; }

    [Display(Name = "Trạng thái")]
    public bool? TrangThai { get; set; }

    [Display(Name = "Mô tả ngắn")]
    [Required(ErrorMessage = "Mô tả không được để trống.")]
    [RegularExpression(@"^[A-Za-z].*", ErrorMessage = "Mô tả phải bắt đầu bằng một chữ cái.")]
    public string? MoTaNgan { get; set; }
    [Display(Name = "Ảnh đại diện")]
    public string? AnhDaiDien { get; set; }
    [Display(Name = "Nổi bật")]
    public bool? NoiBat { get; set; }

    [Display(Name = "Loại sản phụ")]
    public string? MaPhanLoaiPhu { get; set; }

    public virtual PhanLoai? MaPhanLoaiNavigation { get; set; }

    public virtual PhanLoaiPhu? MaPhanLoaiPhuNavigation { get; set; }

    public virtual ICollection<SptheoMau> SptheoMaus { get; set; } = new List<SptheoMau>();
}
