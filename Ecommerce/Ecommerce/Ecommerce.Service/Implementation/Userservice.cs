using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Ecommerce.Model;
using Ecommerce.DTO;
using Ecommerce.Repository.Contract;
using Ecommerce.Service.Contract;
using AutoMapper;

namespace Ecommerce.Service.Implementation
{
    public class Userservice: IUserService
    {
        private readonly IGenericRepository<User> _modelRepository;
        private readonly IMapper _mapper;
        public Userservice(IGenericRepository<User> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<SessionDTO> Authorization(LoginDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.Email == model.Email && p.PasswordUser == model.PasswordUser);
                var fromDbModel = await consult.FirstOrDefaultAsync();
                if (fromDbModel != null)
                {
                    return _mapper.Map<SessionDTO>(fromDbModel);
                }
                else
                {
                    throw new TaskCanceledException("No Coincidences");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> Create(UserDTO model)
        {
             try
            {
                var dbModel = _mapper.Map<User>(model);
                var rspModel = await _modelRepository.Create(dbModel);
                
                if (rspModel.IdUser != 0) {
                    return _mapper.Map<UserDTO>(rspModel);

                }
                else
                {
                    throw new TaskCanceledException("Unable to Create");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdUser == id);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var result = await _modelRepository.Delete(fromDbModel);
                    if (!result)

                        throw new TaskCanceledException("Cannot be Deleted");

                    return result;

                } 
                else
                    throw new TaskCanceledException("Result No Found");
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Edit(UserDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdUser == model.IdUser);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if(fromDbModel != null)
                {
                    fromDbModel.NameUser = model.NameUser;
                    fromDbModel.Email = model.Email;
                    fromDbModel.PasswordUser = model.PasswordUser;
                    var result = await _modelRepository.Edit(fromDbModel);

                    if (!result)
                    
                        throw new TaskCanceledException("Unable to Edit");
                        return result;
                    }
                    else
                    {
                        throw new TaskCanceledException("Results Not Found");
                    }

                }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> Get(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdUser == id);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<UserDTO>(fromDbModel);

                else
                    throw new TaskCanceledException("No Coincidences");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTO>> List(string rol, string search)
        {
            try
            {
                var consult = _modelRepository.Consult(p =>
                p.Rol == rol &&
                string.Concat(p.NameUser.ToLower(), p.Email.ToLower()).Contains(search.ToLower())
                );

                List<UserDTO> list = _mapper.Map<List<UserDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
