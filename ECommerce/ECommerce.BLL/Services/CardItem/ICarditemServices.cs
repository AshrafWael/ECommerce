using ECommerce.BLL.Dtos.CardItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.CardItem
{
    public interface ICarditemServices
    {
         void Add(AddCardItemDto cartItemDto);
        public ReadCardItemDto GetCartItemBy(int id);
        public void UpdateCartItem(ReadCardItemDto cartItemDto);
        public void DeleteCartItem(int id);
    }
}
