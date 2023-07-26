using System;
namespace dotnet_template2023.DTOs.employee;

public class EmployeeReqDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
}

