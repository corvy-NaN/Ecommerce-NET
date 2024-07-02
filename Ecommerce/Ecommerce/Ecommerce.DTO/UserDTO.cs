using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Enter Full Name")]
        public string? NameUser { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string? PasswordUser { get; set; }


        [Required(ErrorMessage = "Enter Password Again")]
        public string? ConfirmPasswordUser { get; set; }


        [Required(ErrorMessage = "Enter Rol")]
        public string? Rol { get; set; }

    }
}
