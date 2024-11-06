using AutoMapper;
using ECommerce.BLL.Dtos.CardItemDtos;
using ECommerce.BLL.Dtos.FavoriteItemDtos;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Reposatories.CardItemRepository;
using ECommerce.DAL.Reposatories.FavoriteItemRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.CardItem
{
    public class CardItemServices :ICarditemServices
    {
        private readonly ICardItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CardItemServices(ICardItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public void Add(AddCardItemDto cartItemDto)
        {
            var cartItem = _mapper.Map<ECommerce.DAL.Data.Models.CardItem>(cartItemDto);

             _mapper.Map<AddCardItemDto>(cartItem);
            _cartItemRepository.Add(cartItem);

        }

        public ReadCardItemDto GetCartItemBy(int id)
        {
            var cartItem =  _cartItemRepository.GetById(id);
            return _mapper.Map<ReadCardItemDto>(cartItem);
        }

        public void UpdateCartItem(ReadCardItemDto cartItemDto)
        {
            var cartItem = _mapper.Map<ECommerce.DAL.Data.Models.CardItem>(cartItemDto);

             _mapper.Map<AddCardItemDto>(cartItem);
             _cartItemRepository.Update(cartItem);

        }

        public void DeleteCartItem(int id)
        {
              _cartItemRepository.DeleteById(id);
        }
    }

  
    }

