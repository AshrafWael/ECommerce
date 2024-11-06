using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Dtos.CategoryDtos
{
    public class AddCategoryDto
    {
        public string Name { get; set; }
        List<CategorryProductsDto> categorryProductsDtos { get; set; }
    }
}
