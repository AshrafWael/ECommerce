using AutoMapper;
using ECommerce.BLL.Dtos.CardItemDtos;
using ECommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.AutoMapper
{
    public class CartItemMapper :Profile
    {
        public CartItemMapper()
        {
            CreateMap<CardItem, AddCardItemDto>().ReverseMap();
            CreateMap<CardItem, ReadCardItemDto>().ReverseMap();

        }
    }
}
