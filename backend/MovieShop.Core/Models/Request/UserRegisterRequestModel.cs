using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    // https://liftcodeplay.files.wordpress.com/2017/07/regexrequirement.png
    // https://liftcodeplay.com/2017/07/15/asp-net-core-password-complexity-validation-using-a-regular-expression-in-a-view-model/
    // ^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$
    // https://stackoverflow.com/questions/48635152/regex-for-default-asp-net-core-identity-password
    public class UserRegisterRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50,ErrorMessage = "Make sure password is reight lenght",MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
