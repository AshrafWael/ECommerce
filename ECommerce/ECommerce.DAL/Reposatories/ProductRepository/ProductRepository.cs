using ECommerce.DAL.Consts;
using ECommerce.DAL.Data.DBHelper;
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
    public class ProductRepository : BaseRepository<Product, int>
                                    , IProductRepository
    {
        private readonly ECommerceContext _context;

        public ProductRepository(ECommerceContext context) : base(context)
        {
           
        }

        public IQueryable<Product> FindAll(Expression<Func<Product, bool>> criteria, int? take,
            int? skip, Expression<Func<Product, object>> orderBy = null, string orderByDirection = null)
        {
            IQueryable<Product> query = _context.Set<Product>().Where(criteria);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.AsQueryable();
        }
    }
}
