using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Reposatories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatories.FavoriteItemRepository
{
    public interface IFavoriteItemRepository :IBaseRepository<FavoriteItem , int >
    {

        public FavoriteItem GetFavouritItemById(int id);
    }
}
