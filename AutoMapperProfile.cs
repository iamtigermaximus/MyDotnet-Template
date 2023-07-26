using System;
using AutoMapper;
using dotnet_template2023.DTOs.employee;
using dotnet_template2023.Models;

namespace dotnet_template2023;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Employee, EmployeeReqDTO>();
        CreateMap<EmployeeReqDTO, Employee>();
        CreateMap<Employee, EmployeeResDTO>();
    }
}

