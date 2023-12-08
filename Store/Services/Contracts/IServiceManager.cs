namespace Services.Contracts;

public interface IServiceManager
{
    ICategoryService CategoryService {get;}
    IProductService ProductService {get;}
    IAuthService AuthService {get;}
}