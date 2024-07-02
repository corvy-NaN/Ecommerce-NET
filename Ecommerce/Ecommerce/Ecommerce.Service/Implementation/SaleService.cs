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
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _modelRepository;
        private readonly IMapper _mapper;
        public SaleService(ISaleRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<SaleDTO> Register(SaleDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Sale>(model);
                var SaleGenerated = await _modelRepository.Register(dbModel);

                if (SaleGenerated.IdSales == 0)
                    throw new TaskCanceledException("Unable to Register");

                return _mapper.Map<SaleDTO>(SaleGenerated);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
