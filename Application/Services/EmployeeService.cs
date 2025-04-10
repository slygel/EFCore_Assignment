using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository repository, IMapper mapper, IDepartmentRepository departmentRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _departmentRepository = departmentRepository;
    }
    
    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        var employees = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto> GetByIdAsync(Guid id)
    {
        var employee = await _repository.GetByIdAsync(id);
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task<EmployeeDto> CreateAsync(EmployeeRequestDto employeeRequestDto)
    {
        var employee = _mapper.Map<Employees>(employeeRequestDto);
        employee.Id = Guid.NewGuid();
        var department = await _departmentRepository.GetByIdAsync(employee.DepartmentId);
        if (department == null)
        {
            throw new DepartmentException(employee.DepartmentId);
        }
        await _repository.AddAsync(employee);
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task UpdateAsync(Guid id, EmployeeRequestDto employeeRequestDto)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null)
        {
            throw new EmployeeException(id);
        }
        var department = await _departmentRepository.GetByIdAsync(employeeRequestDto.DepartmentId);
        if (department == null)
        {
            throw new DepartmentException(employeeRequestDto.DepartmentId);
        }
        _mapper.Map(employeeRequestDto, employee);
        await _repository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null)
        {
            throw new EmployeeException(id);
        }
        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<EmployeeDepartmentDto>> GetAllWithDepartmentAsync()
    {
        var employees = await _repository.GetAllWithDepartmentAsync();
        return _mapper.Map<IEnumerable<EmployeeDepartmentDto>>(employees);
    }

    public async Task<IEnumerable<EmployeeProjectDto>> GetAllWithProjectsAsync()
    {
        var employees = await _repository.GetAllWithProjectsAsync();
        return _mapper.Map<IEnumerable<EmployeeProjectDto>>(employees);
    }

    public async Task<IEnumerable<EmployeeSalaryDto>> GetEmployeesBySalaryAndDateRawSqlAsync(decimal minSalary, DateTime minDate)
    {
        var employees = await _repository.GetEmployeesBySalaryAndDateRawSqlAsync(minSalary, minDate);
        return _mapper.Map<IEnumerable<EmployeeSalaryDto>>(employees);
    }
}