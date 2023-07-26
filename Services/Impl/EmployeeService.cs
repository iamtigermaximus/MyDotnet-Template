using System;
using AutoMapper;
using dotnet_template2023.Data;
using dotnet_template2023.DTOs.employee;
using dotnet_template2023.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_template2023.Services.Impl;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public EmployeeService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<ServiceResponse<List<EmployeeResDTO>>> GetAllProjects()
    {
        var serviceResponse = new ServiceResponse<List<EmployeeResDTO>>();
        var dbProjects = await _context.Employees
           .ToListAsync();

        serviceResponse.Data = dbProjects.Select(c => _mapper.Map<EmployeeResDTO>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<EmployeeResDTO>> GetById(int id)
    {
        var serviceResponse = new ServiceResponse<EmployeeResDTO>();
        try
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(s => s.Id == id);

            serviceResponse.Data = _mapper.Map<EmployeeResDTO>(employee);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<EmployeeResDTO>> Update(EmployeeReqDTO updatedEmployee)
    {
        var serviceResponse = new ServiceResponse<EmployeeResDTO>();

        try
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == updatedEmployee.Id);

            if (employee is null)

                throw new Exception($"Employee  with Id '{updatedEmployee.Id}' not found.");
            employee.Id = updatedEmployee.Id;
            employee.FirstName = updatedEmployee.FirstName;
            employee.LastName = updatedEmployee.LastName;
            employee.Email = updatedEmployee.Email;
            employee.Position = updatedEmployee.Position;
            employee.Salary = updatedEmployee.Salary;

            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<EmployeeResDTO>(employee);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<List<EmployeeResDTO>>> Create(EmployeeReqDTO newEmployee)
    {
        var serviceResponse = new ServiceResponse<List<EmployeeResDTO>>();
        try
        {
            var employee = _mapper.Map<Employee>(newEmployee);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Employees
                    .Select(e => _mapper.Map<EmployeeResDTO>(e))
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<List<EmployeeResDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<EmployeeResDTO>>();

        try
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee is null)
                throw new Exception($"Employee with Id '{id}' not found.");

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Employees.Select(e => _mapper.Map<EmployeeResDTO>(e)).ToListAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}

