using ECommerce.DAL.Consts;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Reposatories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatories.ProductRepository
{
    public interface IProductRepository :IBaseRepository<Product,int>
    {

        IQueryable<Product> FindAll(Expression<Func<Product, bool>> criteria, int? take, int? skip,
            Expression<Func<Product, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

    }
}
