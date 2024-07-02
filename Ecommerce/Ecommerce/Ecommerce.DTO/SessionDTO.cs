using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SessionDTO
    {
        public int IdUser { get; set; }

        public string? NameUser { get; set; }

        public string? Email { get; set; }

        public string? Rol { get; set; }
    }
}
