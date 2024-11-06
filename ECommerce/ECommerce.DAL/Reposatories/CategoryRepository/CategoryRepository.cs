using ECommerce.DAL.Data.DBHelper;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Reposatories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatories.CategoryRepository
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        private readonly ECommerceContext _context;
        public CategoryRepository(ECommerceContext context) : base(context)
        {
            _context = context;
        }
    }
}
