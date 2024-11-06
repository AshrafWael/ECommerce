using AutoMapper;
using ECommerce.BLL.Dtos.CardItemDtos;
using ECommerce.BLL.Dtos.FavoriteItemDtos;
using ECommerce.DAL.Reposatories.FavoriteItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.FavoriteItem
{
    public class FavoriteServices :IFavoriteServices
    {
        private readonly IFavoriteItemRepository _favoriteItemRepository;
        private readonly IMapper _mapper;

        public FavoriteServices(IFavoriteItemRepository favoriteItemRepository, IMapper mapper)
        {
            _favoriteItemRepository = favoriteItemRepository;
            _mapper = mapper;
        }

        public void Add(FavoritItemDto  favoritItemDto)
        {
            var favoriteItem = _mapper.Map<ECommerce.DAL.Data.Models.FavoriteItem>(favoritItemDto);

            _mapper.Map<FavoritItemDto>(favoriteItem);
            _favoriteItemRepository.Add(favoriteItem);

        }

        public FavoritItemDto GetFavouritItemById(int id)
        {
            var favoriteItem = _favoriteItemRepository.GetById(id);
            return _mapper.Map<FavoritItemDto>(favoriteItem);
        }

        public void UpdateFavouritItem(FavoritItemDto  favoritItemDto)
        {
            var FavItem = _mapper.Map<ECommerce.DAL.Data.Models.FavoriteItem>(favoritItemDto);

            _mapper.Map<FavoritItemDto>(FavItem);
            _favoriteItemRepository.Update(FavItem);

        }

        public void DeleteFavoriteItem(int id)
        {
            _favoriteItemRepository.DeleteById(id);
        }
    }

}

