using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Enter Email")]
        public string? Email { get; set; }



        [Required(ErrorMessage = "Enter Password")]
        public string? PasswordUser { get; set; }

    }
}
