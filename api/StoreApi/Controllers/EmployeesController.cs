using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    [HttpGet] // ./api/employees
    public List<string> GetAllEmployees()
    {
        var employees = new List<String>();
        employees.Add("Ahmet");
        employees.Add("Mehmet");
        employees.Add("Can");
        employees.Add("Filiz");

        return employees;
    }
}