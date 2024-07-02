using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SalesDetailDTO
    {
        public int IdSalesDetail { get; set; }

        public int? IdProduct { get; set; }

        public int? Amount { get; set; }

        public decimal? Total { get; set; }

    }

}
