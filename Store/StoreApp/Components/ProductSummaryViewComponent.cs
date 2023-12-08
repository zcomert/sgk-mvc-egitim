using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components;

public class ProductSummaryViewComponent : ViewComponent
{
    private readonly IServiceManager _manager;

    public ProductSummaryViewComponent(IServiceManager manager)
    {
        _manager = manager;
    }

    public IViewComponentResult Invoke()
    {
        var model = _manager.ProductService.GetAllProducts().Count();
        return View(model);
    }
}