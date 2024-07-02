using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;

namespace Ecommerce.Service.Contract
{
    public interface IDashBoardService
    {
        DashBoardDTO Summary();
    }
}
