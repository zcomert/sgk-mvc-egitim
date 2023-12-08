using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IAuthService _authService;

    public ServiceManager(ICategoryService categoryService,
        IProductService productService,
        IAuthService authService)
    {
        _categoryService = categoryService;
        _productService = productService;
        _authService = authService;
    }

    public ICategoryService CategoryService => _categoryService;

    public IProductService ProductService => _productService;

    public IAuthService AuthService => _authService;
}