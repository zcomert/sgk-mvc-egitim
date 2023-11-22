using BasicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicApp.Controllers;

public class SGKController : Controller
{
    public List<Employee> list { get; set; }
    public SGKController()
    {
        list = new List<Employee>()
        {
            new Employee() { Id = 1, FirstName = "Ahmet", LastName = "Can", Salary = 35_0000 },
            new Employee() { Id = 2, FirstName = "Mehmet", LastName = "Yılmaz", Salary = 40_000 },
            new Employee() { Id = 3, FirstName = "Ayşe", LastName = "Demir", Salary = 45_000 },
            new Employee() { Id = 4, FirstName = "Fatma", LastName = "Yıldız", Salary = 38_000 },
            new Employee() { Id = 5, FirstName = "Mustafa", LastName = "Aydın", Salary = 42_000 },
        };
    }
    public IActionResult Employee()
    {
        Employee emp = new Employee()
        {
            Id = 1,
            FirstName = "Ahmet",
            LastName = "Can",
            Salary = 40_000
        };
        return View(model: emp);
    }

    public IActionResult Employees()
    {
        var model = list.ToArray();
        return View(model);
    }

    public IActionResult Get(int id)
    {
        var model = list
                .SingleOrDefault(emp => emp.Id.Equals(id));
        return View("Employee", model);
    }

}