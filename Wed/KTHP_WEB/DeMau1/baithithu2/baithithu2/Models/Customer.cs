using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace baithithu2.Models;

public partial class Customer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Fullname is required")]
    public string Fullname { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Re-enter your password")]
    [DataType(DataType.Password)]
    
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string RePassword { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
