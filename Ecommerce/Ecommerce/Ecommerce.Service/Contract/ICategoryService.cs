using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.Service.Contract
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> List(string search);
        Task<CategoryDTO> Get(int id);
        Task<CategoryDTO> Create(CategoryDTO model);
        Task<bool> Edit(CategoryDTO model);
        Task<bool> Delete(int id);
    }
}
