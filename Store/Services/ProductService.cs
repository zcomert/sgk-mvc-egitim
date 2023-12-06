using System.Linq.Expressions;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class ProductService : IProductService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public ProductService(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public void CreateOneProduct(ProductDtoForInsertion productDto)
    {
        // var product = new Product()
        // {
        //     CategoryId = productDto.CategoryId,
        //     ProductName = productDto.ProductName,
        //     Price = productDto.Price
        // };

        var product = _mapper.Map<Product>(productDto);

        _manager.ProductRepository.Create(product);
        _manager.Save();
    }

    public void DeleteOneProduct(int id)
    {
        var product = GetOneProduct(id);
        _manager.ProductRepository.Delete(product);
        _manager.Save();
    }

    public IEnumerable<Product> GetAllProducts(Expression<Func<Product, bool>> filter = null,
        bool isTracking = false)
    {
        return _manager
                .ProductRepository
                .ReadAll(filter,isTracking);
    }

    public IEnumerable<Product> GetAllProductsWithDetails()
    {
        return _manager
        .ProductRepository
        .GetAllProductsWithDetails();
    }

    public Product? GetOneProduct(int id, bool isTracking=true)
    {
        var product = _manager
                    .ProductRepository
                    .Read(prd => prd.ProductId.Equals(id), isTracking);
        
        if (product is null)
            throw new Exception();

        return product;
    }

    public ProductDtoForUpdate? GetOneProductDtoForUpdate(int id, bool isTracking = true)
    {
        var product = GetOneProduct(id, isTracking);
        return _mapper.Map<ProductDtoForUpdate>(product);
    }

    public void UpdateOneProduct(int id, ProductDtoForUpdate productDto)
    {
        var prd = GetOneProduct(id,false); // tracking ProductId

        prd = _mapper.Map<Product>(productDto);
        
        _manager.ProductRepository.Update(prd);
        _manager.Save();
        
        // if (id.Equals(product.ProductId))
        // {
        //     prd.ProductName = product.ProductName;
        //     prd.Price = product.Price;

        //     _manager.ProductRepository.Update(prd);
        //     _manager.Save();
        // }
    
    }
}