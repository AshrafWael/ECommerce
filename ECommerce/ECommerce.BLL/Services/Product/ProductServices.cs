using AutoMapper;
using ECommerce.DAL.Data.Models;
using ECommerce.BLL.Dtos.ProductDtos;
using ECommerce.DAL.Reposatories.ProductRepository;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.Product
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductServices(IProductRepository productRepo,IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public void Add(ProductAddDto productAddDto)
        {
            var products = _mapper.Map<ECommerce.DAL.Data.Models.Product>(productAddDto);  
            _productRepo.Add(products);
        }
        public IQueryable<ProductReadDto> GetAll()
        {
            var products = _productRepo.GetAll();
            return _mapper.ProjectTo<ProductReadDto>(products);
        }

        public void DeleteById(int id)
        {
            var product = _productRepo.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
            _productRepo.DeleteById(id);
        }

        public ProductReadDto Find(Expression<Func<ProductReadDto, bool>> criteria)
        {
            var product = _productRepo.Find(_mapper.Map<Expression<Func<ECommerce.DAL.Data.Models.Product, bool>>>(criteria));
            return _mapper.Map<ProductReadDto>(product);
        }
        public ProductReadDto GetById(int id)
        {
            var product =  _productRepo.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
            return _mapper.Map<ProductReadDto>(product);
        }
        
        public void Update(ProductUpdateDto productupdateDto)
        {
            var existingProduct = _productRepo.GetById(productupdateDto.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
            var updatedProduct = _mapper.Map(productupdateDto, existingProduct);
            _productRepo.Update(updatedProduct);
        
        }
        
    }
}

