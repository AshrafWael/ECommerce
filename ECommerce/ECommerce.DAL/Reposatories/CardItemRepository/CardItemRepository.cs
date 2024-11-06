using ECommerce.DAL.Data.DBHelper;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Reposatories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatories.CardItemRepository
{
    public class CardItemRepository : BaseRepository<CardItem, int>, ICardItemRepository
    {
        private readonly ECommerceContext _context;

        public CardItemRepository(ECommerceContext context) : base(context)
        {
            _context = context;
            
        }

        public CardItem GetCardItemById(int id)
        {
            return _context.CardItems
                    .Include(ci => ci.Product)
                    .FirstOrDefault(ci => ci.Id == id);
        }
    }
}
