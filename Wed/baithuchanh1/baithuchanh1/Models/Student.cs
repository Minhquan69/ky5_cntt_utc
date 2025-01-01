using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace baithuchanh1.Models
{
    public class Student
    {
        public int Id { get; set; } // Mã sinh viên

        [Required(ErrorMessage = "Họ tên bắt buộc phải được nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có độ dài từ 4 đến 100 ký tự")]
        public string? Name { get; set; } // Họ tên

        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi gmail.com")]
        public string? Email { get; set; } // Email

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có độ dài từ 8 kí tự, có viết hoa, ...")]
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải được nhập")]
        public string? Password { get; set; } // Mật khẩu

        [Required(ErrorMessage = "Ngành học bắt buộc phải được chọn")]
        public Branch? Branch { get; set; } // Ngành học

        [Required(ErrorMessage = "Giới tính bắt buộc phải được chọn")]
        public Gender? Gender { get; set; } // Giới tính

        public bool IsRegular { get; set; } // Hệ: true-chính quy, false-phi chính quy

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải được nhập")]
        public string? Address { get; set; } // Địa chỉ

        [Range(typeof(DateTime), "1/1/1963", "12/1/2005", ErrorMessage = "Ngày sinh phải nằm trong khoảng từ 1/1/1963 đến 12/1/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải được nhập")]
        public DateTime? DateOfBirth { get; set; } // Ngày sinh
        [Required(ErrorMessage = "Điểm không được bỏ trống.")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0.")]
        public double? Diem { get; set; }
    }
}
