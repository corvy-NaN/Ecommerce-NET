using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? NameProduct { get; set; }

    public string? DescriptionProduct { get; set; }

    public int? IdCategory { get; set; }

    public decimal? Price { get; set; }

    public decimal? PriceSale { get; set; }

    public int? Amount { get; set; }

    public string? ImageProduct { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
    public object IdCategoryNavegation { get; set; }
}
