using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace baithuchanh1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được bỏ trống.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có độ dài từ 4 đến 100 ký tự.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email không được bỏ trống.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email phải có đuôi gmail.com.")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Mật khẩu không được bỏ trống.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Mật khẩu phải chứa ít nhất một ký tự viết hoa, một ký tự viết thường, một chữ số và một ký tự đặc biệt.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Branch không được bỏ trống.")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Giới tính không được bỏ trống.")]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống.")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Ngày sinh không được bỏ trống.")]
        [Range(typeof(DateTime), "1/1/1963", "12/1/2005", ErrorMessage = "Ngày sinh phải nằm trong khoảng từ 1/1/1963 đến 12/1/2005.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Điểm không được bỏ trống.")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0.")]
        [RegularExpression(@"^\d+(\.\d{1})?$", ErrorMessage = "Điểm chỉ được phép có 1 chữ số thập phân.")]


       

        public double? Diem { get; set; }
    }
}
