﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Repository.DBContext;
using Ecommerce.Repository.Contract;
using System.Linq.Expressions;


namespace Ecommerce.Repository.Implementation
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly EcommerceContext _dbContext;
        public GenericRepository (EcommerceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TModel> Consult(Expression<Func<TModel, bool>>? filtro = null)
        {
            IQueryable<TModel> consult = (filtro == null)? _dbContext.Set<TModel>():_dbContext.Set<TModel>().Where(filtro);
            return consult;
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
