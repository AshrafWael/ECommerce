
using AutoMapper;
using ECommerce.BLL.Dtos.ProductDtos;
using ECommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.AutoMapper
{
    public class ProductMapper :Profile
    {
        public ProductMapper()
        {
            CreateMap<Product,ProductReadDto>().ReverseMap();
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap(); 

        }
    }
}
