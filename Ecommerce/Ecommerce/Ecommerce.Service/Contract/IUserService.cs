using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.DTO;


namespace Ecommerce.Service.Contract
{
    public interface IUserService
    {
        Task<List<UserDTO>> List(string rol, string search);
        Task<UserDTO> Get(int id);
        Task<SessionDTO> Authorization(LoginDTO model);
        Task<UserDTO> Create(UserDTO model);
        Task<bool> Edit(UserDTO model);
        Task<bool> Delete(int id);


    }
}
