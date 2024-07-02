using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class SalesDetail
{
    public int IdSalesDetail { get; set; }

    public int? IdSales { get; set; }

    public int? IdProduct { get; set; }

    public int? Amount { get; set; }

    public decimal? Total { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Sale? IdSalesNavigation { get; set; }
}
