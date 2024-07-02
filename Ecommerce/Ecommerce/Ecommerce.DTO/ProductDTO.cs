using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string? NameProduct { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        public string? DescriptionProduct { get; set; }

        public int? IdCategory { get; set; }

        [Required(ErrorMessage = "Enter Price")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Enter Price with Sale")]
        public decimal? PriceSale { get; set; }

        [Required(ErrorMessage = "Enter Amount")]
        public int? Amount { get; set; }

        [Required(ErrorMessage = "Enter Image")]
        public string? ImageProduct { get; set; }

        public DateTime? CreationDate { get; set; }


        public virtual CategoryDTO? IdCategoryNavigation { get; set; }
    }
}
