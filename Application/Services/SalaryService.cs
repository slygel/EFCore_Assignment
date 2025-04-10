using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class SalaryService : ISalaryService
{
    private readonly ISalaryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public SalaryService(ISalaryRepository repository, IMapper mapper, IEmployeeService employeeService)
    {
        _repository = repository;
        _mapper = mapper;
        _employeeService = employeeService;
    }
    
    public async Task<IEnumerable<SalaryDto>> GetAllAsync()
    {
        var salaries = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<SalaryDto>>(salaries);
    }

    public async Task<SalaryDto> GetByIdAsync(Guid id)
    {
        var salary = await _repository.GetByIdAsync(id);
        return _mapper.Map<SalaryDto>(salary);
    }

    public async Task<SalaryDto> CreateAsync(SalaryRequestDto salaryRequestDto)
    {
        var employee = await _employeeService.GetByIdAsync(salaryRequestDto.EmployeeId);
        if (employee == null)
        {
            throw new EmployeeException(salaryRequestDto.EmployeeId);
        }
        var salary = _mapper.Map<Salaries>(salaryRequestDto);
        salary.Id = Guid.NewGuid();
        await _repository.AddAsync(salary);
        return _mapper.Map<SalaryDto>(salary);
    }

    public async Task UpdateAsync(Guid id, SalaryRequestDto salaryRequestDto)
    {
        var salary = await _repository.GetByIdAsync(id);
        if (salary == null)
        {
            throw new SalaryException(id);
        }
        var employee = await _employeeService.GetByIdAsync(salaryRequestDto.EmployeeId);
        if (employee == null)
        {
            throw new EmployeeException(salaryRequestDto.EmployeeId);
        }
        _mapper.Map(salaryRequestDto, salary);
        await _repository.UpdateAsync(salary);
    }

    public async Task DeleteAsync(Guid id)
    {
        var salary = await _repository.GetByIdAsync(id);
        if (salary == null)
        {
            throw new SalaryException(id);
        }
        await _repository.DeleteAsync(id);
    }
}