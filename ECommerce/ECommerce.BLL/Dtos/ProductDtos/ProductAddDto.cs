﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Dtos.ProductDtos
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
