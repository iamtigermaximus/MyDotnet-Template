using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_template2023.DTOs.employee;
using dotnet_template2023.Models;
using dotnet_template2023.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_template2023.Controllers;

[ApiController]
[Route("api/v1/Employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet()]
    public async Task<ActionResult<ServiceResponse<List<EmployeeResDTO>>>> GetAll()
    {
        var projects = await _employeeService.GetAllProjects();
        return Ok(projects.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<EmployeeResDTO>>>> GetSingle(int id)
    {
        return Ok(await _employeeService.GetById(id));
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<EmployeeResDTO>>>> AddEmployee(EmployeeReqDTO newEmployee)
    {
        return Ok(await _employeeService.Create(newEmployee));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeResDTO>>> UpdateProject(int id, EmployeeReqDTO updatedEmployee)
    {
        var response = await _employeeService.Update(updatedEmployee);

        if (!response.Success)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<EmployeeResDTO>>> Delete(int id)
    {
        var response = await _employeeService.Delete(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }

        return Ok(response);
    }
}

