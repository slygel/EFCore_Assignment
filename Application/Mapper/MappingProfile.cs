using Application.DTOs.Requests;
using Application.DTOs.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Departments
        CreateMap<Departments, DepartmentDto>();
        CreateMap<DepartmentRequestDto, Departments>();
        
        // Employees
        CreateMap<Employees, EmployeeDto>()
            .ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate.Date));
        CreateMap<EmployeeRequestDto, Employees>()
            .ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => src.JoinedDate.Date));
        
        // Project
        CreateMap<Projects, ProjectDto>();
        CreateMap<ProjectRequestDto, Projects>();
        
        // Salary
        CreateMap<Salaries, SalaryDto>();
        CreateMap<SalaryRequestDto, Salaries>();

        // ProjectEmployee
        CreateMap<ProjectEmployee, ProjectEmployeeDto>();
        CreateMap<ProjectEmployeeRequestDto, ProjectEmployee>();
        CreateMap<UpdateProjectEmployeeDto, ProjectEmployee>();
        
        
        CreateMap<Employees, EmployeeDepartmentDto>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.DepartmentName,opt => opt.MapFrom(src => src.Department.Name));

        CreateMap<Employees, EmployeeProjectDto>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => 
                src.ProjectEmployees.Select(pe => new ProjectInfo
                {
                    ProjectId = pe.ProjectId,
                    ProjectName = pe.Projects.Name
                }).ToList()));

        CreateMap<Employees, EmployeeSalaryDto>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary.Salary));
    }
}