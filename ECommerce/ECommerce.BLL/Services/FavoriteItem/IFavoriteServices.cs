using ECommerce.BLL.Dtos.FavoriteItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.FavoriteItem
{
    public interface IFavoriteServices 
    {

        public void Add(FavoritItemDto favoritItemDto);
        public FavoritItemDto GetFavouritItemById(int id);
        public void UpdateFavouritItem(FavoritItemDto favoritItemDto);
        public void DeleteFavoriteItem(int id);


    }
}
