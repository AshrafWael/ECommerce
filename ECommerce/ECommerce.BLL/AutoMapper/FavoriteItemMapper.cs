using AutoMapper;
using ECommerce.BLL.Dtos.FavoriteItemDtos;
using ECommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.AutoMapper
{
    public class FavoriteItemMapper :Profile
    {
        public FavoriteItemMapper()
        {
        CreateMap<FavoriteItem, FavoritItemDto>().ReverseMap();
            
        }

    }
}
