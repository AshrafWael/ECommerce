using ECommerce.BLL.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.Product
{
    public interface IProductServices 
    {

        IQueryable<ProductReadDto> GetAll();
        ProductReadDto GetById(int id);
        ProductReadDto Find(Expression<Func<ProductReadDto, bool>> criteria);
        void Add(ProductAddDto productAddDto);
        void Update(ProductUpdateDto productupdateDto);
        void DeleteById(int id);
    }
}
