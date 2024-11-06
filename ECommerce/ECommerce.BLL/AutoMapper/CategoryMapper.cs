using AutoMapper;
using ECommerce.BLL.Dtos.CategoryDtos;
using ECommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.AutoMapper
{
    public class CategoryMapper :Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoruyDto>().ReverseMap();

        }
    }
}
