namespace staff_management.Models;

public class AddEmployeeViewModel
{   
    public string? Name { get; set; }
    public DateTime Dob { get; set; }
    public long Salary { get; set; }
    public string? Email { get; set; }
    public string? Department { get; set; }
}