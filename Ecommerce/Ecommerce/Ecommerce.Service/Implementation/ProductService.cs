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
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _modelRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> Catalog(string category, string search)
        {
            try
            {
                var consult = _modelRepository.Consult(p =>
                p.NameProduct.ToLower().Contains(search.ToLower()) &&
                p.IdCategoryNavigation.NameCategory.ToLower().Contains(category.ToLower())
                );

                List<ProductDTO> list = _mapper.Map<List<ProductDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDTO> Create(ProductDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Product>(model);
                var rspModel = await _modelRepository.Create(dbModel);

                if (rspModel.IdProduct != 0)
                {
                    return _mapper.Map<ProductDTO>(rspModel);

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
                var consult = _modelRepository.Consult(p => p.IdProduct == id);
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

        public async Task<bool> Edit(ProductDTO model)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdProduct == model.IdProduct);
                var fromDbModel = await consult.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.NameProduct = model.NameProduct;
                    fromDbModel.DescriptionProduct = model.DescriptionProduct;
                    fromDbModel.IdCategory = model.IdCategory;
                    fromDbModel.Price = model.Price;
                    fromDbModel.PriceSale = model.PriceSale;
                    fromDbModel.Amount = model.Amount;
                    fromDbModel.ImageProduct = model.ImageProduct;
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

        public async Task<ProductDTO> Get(int id)
        {
            try
            {
                var consult = _modelRepository.Consult(p => p.IdProduct == id);
                consult = consult.Include(c => c.IdCategoryNavigation);
                var fromDbModel = await consult.FirstOrDefaultAsync();


                if (fromDbModel != null)
                    return _mapper.Map<ProductDTO>(fromDbModel);

                else
                    throw new TaskCanceledException("No Coincidences");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> List(string search)
        {
            try
            {
                var consult = _modelRepository.Consult(p =>
                p.NameProduct.ToLower().Contains(search.ToLower())
                );

                consult = consult.Include(c => c.IdCategoryNavigation);

                List<ProductDTO> list = _mapper.Map<List<ProductDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
