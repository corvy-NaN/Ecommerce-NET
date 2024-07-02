using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Repository.DBContext;
using Ecommerce.Repository.Contract;
using Ecommerce.Model;

namespace Ecommerce.Repository.Implementation
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly EcommerceContext _dbContext;
        public SaleRepository(EcommerceContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sale> Register(Sale model)
        {
            Sale SaleCompleted = new Sale();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach(SalesDetail sd in model.SalesDetails)
                    {
                        Product product_found = _dbContext.Products.Where(p => p.IdProduct == sd.IdProduct).First();
                        product_found.Amount = product_found.Amount - sd.Amount;
                        _dbContext.Products.Update(product_found);
                    }
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Sales.AddAsync(model);
                    await _dbContext.SaveChangesAsync();
                    SaleCompleted = model;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return SaleCompleted;
        }
    }
}
