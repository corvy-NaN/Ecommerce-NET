using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CardDTO
    {
        [Required(ErrorMessage = "Enter Owner")]
        public string? Owner {  get; set; }
        [Required(ErrorMessage = "Enter Card Number")]
        public string? Number { get; set;}
        [Required(ErrorMessage = "Enter Expiration Date")]
        public string? Expiration { get; set; }
        [Required(ErrorMessage = "Enter CVV")]
        public string? CVV { get; set; }


    }
}
