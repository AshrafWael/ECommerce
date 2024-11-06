using ECommerce.DAL.Data.DBHelper;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Reposatories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatories.FavoriteItemRepository
{
    public class FavoriteItemRepository : BaseRepository<FavoriteItem, int>, IFavoriteItemRepository
    {
        private readonly ECommerceContext _context;

        public FavoriteItemRepository(ECommerceContext context) : base(context)
        {
            _context = context;
        }

        public FavoriteItem GetFavouritItemById(int id)
        {
            return _context.favoriteItems
                .Include(fi => fi.Product)
                .FirstOrDefault(fi => fi.Id == id);
        }
    }
}
