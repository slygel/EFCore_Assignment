using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        var departments = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }

    public async Task<DepartmentDto> GetByIdAsync(Guid id)
    {
        var department = await _repository.GetByIdAsync(id);
        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task<DepartmentDto> CreateAsync(DepartmentRequestDto departmentDto)
    {
        var department = _mapper.Map<Departments>(departmentDto);
        department.Id = Guid.NewGuid();
        await _repository.AddAsync(department);
        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task UpdateAsync(Guid id, DepartmentRequestDto departmentDto)
    {
        var department = await _repository.GetByIdAsync(id);
        if (department == null)
        {
            throw new DepartmentException(id);
        }
        _mapper.Map(departmentDto, department);
        await _repository.UpdateAsync(department);
    }

    public async Task DeleteAsync(Guid id)
    {
        var department = await _repository.GetByIdAsync(id);
        if (department == null)
        {
            throw new DepartmentException(id);
        }
        await _repository.DeleteAsync(id);
    }
}