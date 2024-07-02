using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.Model;


namespace Ecommerce.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<User, SessionDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>().ForMember(destination => destination.IdCategoryNavigation, opt => opt.Ignore());

            CreateMap<SalesDetail, SalesDetailDTO>();
            CreateMap<SalesDetailDTO, SalesDetail>();

            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleDTO, Sale>();
        }
    }
}
