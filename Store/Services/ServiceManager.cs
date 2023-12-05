using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public ServiceManager(ICategoryService categoryService,
        IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }

    public ICategoryService CategoryService => _categoryService;

    public IProductService ProductService => _productService;
}