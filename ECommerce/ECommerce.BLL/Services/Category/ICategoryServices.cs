using ECommerce.BLL.Dtos.CategoryDtos;
using ECommerce.BLL.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.Category
{
    public interface ICategoryServices
    {
        IQueryable<UpdateCategoruyDto> GetAll();
        UpdateCategoruyDto GetById(int id);
        UpdateCategoruyDto Find(Expression<Func<UpdateCategoruyDto, bool>> criteria);
        void Add(AddCategoryDto  addCategoryDto);
        void Update(UpdateCategoruyDto  updateCategoruyDto);
        void DeleteById(int id);
    }
}
