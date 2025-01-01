using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace De2.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không khớp.")]
    public string RePassword { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
