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
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _modelRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Category>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdCategory != 0)
                {
                    return _mapper.Map<CategoryDTO>(rspModel);

                }
                else
                {
                    throw new TaskCanceledException("Unable to Create");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdCategory == id);
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

        public async Task<bool> Edit(CategoryDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdCategory == model.IdCategory);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.NameCategory = model.NameCategory;
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

        public async Task<CategoryDTO> Get(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdCategory == id);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                    return _mapper.Map<CategoryDTO>(fromDbModel);

                else
                    throw new TaskCanceledException("No Coincidences");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryDTO>> List(string search)
        {
            try
            {
                var consult = _modelRepository.Consult(p =>
                string.Concat(p.NameCategory.ToLower()).Contains(search.ToLower())
                );

                List<CategoryDTO> list = _mapper.Map<List<CategoryDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }
