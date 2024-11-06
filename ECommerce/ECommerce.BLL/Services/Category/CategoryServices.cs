using AutoMapper;
using ECommerce.DAL.Data.Models;
using ECommerce.BLL.Dtos.CategoryDtos;
using ECommerce.BLL.Dtos.ProductDtos;
using ECommerce.DAL.Reposatories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.Category
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public void Add(AddCategoryDto addCategoryDto)
        {
            var ProductsModel = _mapper.Map<ECommerce.DAL.Data.Models.Category>(addCategoryDto);
            _categoryRepository.Add(ProductsModel);

        }

        public void DeleteById(int id)
        {
             var categorie = _categoryRepository.GetById(id);
            if (id == categorie.Id)
            {
                _categoryRepository.DeleteById(id);
            }
            else 
            {
                throw new KeyNotFoundException("Product not found.");

            }

        }
        public IQueryable<UpdateCategoruyDto> GetAll()
        {

            var categories = _categoryRepository.GetAll();
            return _mapper.ProjectTo<UpdateCategoruyDto>(categories);

        }
        public UpdateCategoruyDto GetById(int id)
        {
            var categori = _categoryRepository.GetById(id);
            if (categori  == null)
            {
                throw new KeyNotFoundException("category not found.");
            } 
            return _mapper.Map<UpdateCategoruyDto>(categori);

        
        }
        public UpdateCategoruyDto Find(Expression<Func<UpdateCategoruyDto, bool>> criteria)
        {
            var cat = _mapper.Map<Expression<Func<ECommerce.DAL.Data.Models.Category, bool>>>(criteria);
            var categori = _categoryRepository.Find(cat);
            return _mapper.Map<UpdateCategoruyDto>(categori);
        }
        public void Update(UpdateCategoruyDto updateCategoruyDto)
        {
            var category = _categoryRepository.GetById(updateCategoruyDto.Id);
            if (category == null)
            {
                throw new KeyNotFoundException("CATEGORY not found.");
            }
            else 
            {
                _mapper.Map<ECommerce.DAL.Data.Models.Category>(updateCategoruyDto);
                _categoryRepository.Update(category);
            }

        }
    }
}
