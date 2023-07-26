using System;
using dotnet_template2023.Models;

namespace dotnet_template2023.DTOs.employee;

public class EmployeeResDTO:BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
}

