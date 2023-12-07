using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages;

public class DemoModel : PageModel
{
    public String? FullName { get; set; } = "Ahmet";
}