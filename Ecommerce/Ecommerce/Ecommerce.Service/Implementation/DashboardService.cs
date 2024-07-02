using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.Implementation;
using Ecommerce.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Implementation
{
    public class DashboardService : IDashBoardService
    {
            private readonly ISaleRepository _saleRepository;
            private readonly IGenericRepository<User> _userRepository;
            private readonly IGenericRepository<Product> _productRepository;
            public DashboardService(
                ISaleRepository saleRepository,
                IGenericRepository<User> userRepository,
                IGenericRepository<Product> productRepository
                )
            {
                _saleRepository = saleRepository;
                _userRepository = userRepository;
                _productRepository = productRepository;
            }

        private string income()
        {
            var consult = _saleRepository.Consult();
            decimal? income = consult.Sum(x => x.Total);
            return Convert.ToString(income);
        }

        private int Sales()
        {
            var consult = _saleRepository.Consult();
            int Total = consult.Count();
            return Total;
        }

        private int Customers()
        {
            var consult = _userRepository.Consult(u => u.Rol.ToLower() == "Customer");
            int Total = consult.Count();
            return Total;
        }

        private int Products()
        {
            var consult = _productRepository.Consult();
            int Total = consult.Count();
            return Total;
        }

        public DashBoardDTO Summary()
        {
            try
            {
                DashBoardDTO dto = new DashBoardDTO()
                {
                    TotalIncome = income(),
                    TotalSales = Sales(),
                    TotalCustomers = Customers(),
                    TotalProducts = Products()

                };
                return dto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
