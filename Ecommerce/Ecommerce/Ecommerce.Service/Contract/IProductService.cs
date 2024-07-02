using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Contract
{
    public interface IProductService
    {
        Task<List<ProductDTO>> List(string search);
        Task<List<ProductDTO>> Catalog(string category, string search);
        Task<ProductDTO> Get(int id);
        Task<ProductDTO> Create(ProductDTO model);
        Task<bool> Edit(ProductDTO model);
        Task<bool> Delete(int id);
    }
}
