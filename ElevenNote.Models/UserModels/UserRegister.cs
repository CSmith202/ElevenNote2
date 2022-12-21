using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class UserRegister
{

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(4)]
    public string UserName { get; set; }

    [Required]
    [MinLength(4)]
    public string Password { get; set; }

    [Compare(nameof(Password))]
    public string ConfirmedPassword { get; set; }

}