using System;
using System.Collections.Generic;

namespace Ecommerce.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string? NameUser { get; set; }

    public string? Email { get; set; }

    public string? PasswordUser { get; set; }

    public string? Rol { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
