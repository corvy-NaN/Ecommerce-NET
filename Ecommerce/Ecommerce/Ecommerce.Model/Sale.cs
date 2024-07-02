using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class Sale
{
    public int IdSales { get; set; }

    public int? IdUser { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
