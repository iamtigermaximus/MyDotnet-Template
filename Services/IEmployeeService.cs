using System;
using dotnet_template2023.DTOs.employee;
using dotnet_template2023.Models;

namespace dotnet_template2023.Services;

public interface IEmployeeService
{
    Task<ServiceResponse<List<EmployeeResDTO>>> GetAllProjects();
    Task<ServiceResponse<EmployeeResDTO>> GetById(int id);
    Task<ServiceResponse<List<EmployeeResDTO>>> Create(EmployeeReqDTO newEmployee);
    Task<ServiceResponse<EmployeeResDTO>> Update(EmployeeReqDTO updatedEmployee);
    Task<ServiceResponse<List<EmployeeResDTO>>> Delete(int id);
}

