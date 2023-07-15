using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using staff_management.Models;

namespace staff_management.Controllers;

public class EmployeeController : Controller
{
    public EmployeeController()
    {
        
    }
    public IActionResult Add()
    {
        return View();
    }

    public IActionResult Add(AddEmployeeViewModel model)
    {
        var newEmployee = new Employee()
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            Email = model.Email,
            Salary = model.Salary,
            Dob = model.Dob,
            Department = model.Department
        };
        return View();
    }
}
