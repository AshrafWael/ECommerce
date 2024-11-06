﻿using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Reposatories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Reposatories.CardItemRepository
{
    public interface ICardItemRepository  :IBaseRepository<CardItem ,int >
    {
        public CardItem GetCardItemById(int id);
    }
}
