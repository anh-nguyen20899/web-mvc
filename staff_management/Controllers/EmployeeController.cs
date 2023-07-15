using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staff_management.Data;
using staff_management.Models;

namespace staff_management.Controllers;

public class EmployeeController : Controller
{
    private EmployeeContext _context;
    public EmployeeController(EmployeeContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var employees = await _context.MyEmployees.ToListAsync();
        return View(employees);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddEmployeeViewModel model)
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
        await _context.MyEmployees.AddAsync(newEmployee);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> View(Guid id)
    {
        var employee = await _context.MyEmployees.FirstOrDefaultAsync(e => e.Id == id);
        if (employee != null)
        {
            var editEmployeeViewModel = new EditEmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Dob = employee.Dob,
                Salary = employee.Salary,
                Department = employee.Department
            };
            return await Task.Run(() => View("View", editEmployeeViewModel));
        }
        
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> View(EditEmployeeViewModel model)
    {
        var employee = await _context.MyEmployees.FindAsync(model.Id);
        if(employee != null)
        {
            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.Department = model.Department;
            employee.Dob = model.Dob;
            employee.Salary = model.Salary;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> Delete(EditEmployeeViewModel model)
    {
        var employee = await _context.MyEmployees.FindAsync(model.Id);
        if (employee != null)
        {
            _context.MyEmployees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
}
