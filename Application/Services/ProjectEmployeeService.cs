using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProjectEmployeeService : IProjectEmployeeService
{
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    
    public ProjectEmployeeService(
        IProjectEmployeeRepository projectEmployeeRepository,
        IProjectRepository projectRepository,
        IEmployeeRepository employeeRepository,
        IMapper mapper)
    {
        _projectEmployeeRepository = projectEmployeeRepository;
        _projectRepository = projectRepository;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProjectEmployeeDto>> GetAllAsync()
    {
        var projectEmployees = await _projectEmployeeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProjectEmployeeDto>>(projectEmployees);
    }

    public async Task<ProjectEmployeeDto> GetByIdsAsync(Guid projectId, Guid employeeId)
    {
        var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(projectId, employeeId);
        if (projectEmployee == null)
        {
            throw new ProjectEmployeeException(projectId, employeeId);
        }
        return _mapper.Map<ProjectEmployeeDto>(projectEmployee);
    }

    public async Task<ProjectEmployeeDto> CreateAsync(ProjectEmployeeRequestDto projectEmployeeRequest)
    {
        var employee = await _employeeRepository.GetByIdAsync(projectEmployeeRequest.EmployeeId);
        if (employee == null)
        {
            throw new ProjectEmployeeException(projectEmployeeRequest.ProjectId, projectEmployeeRequest.EmployeeId);
        }
        var project = await _projectRepository.GetByIdAsync(projectEmployeeRequest.ProjectId);
        if (project == null)
        {
            throw new ProjectEmployeeException(projectEmployeeRequest.ProjectId, projectEmployeeRequest.ProjectId);
        }
        var projectEmployee = _mapper.Map<ProjectEmployee>(projectEmployeeRequest);
        await _projectEmployeeRepository.AddAsync(projectEmployee);
        return _mapper.Map<ProjectEmployeeDto>(projectEmployee);
    }

    public async Task UpdateAsync(Guid projectId, Guid employeeId, UpdateProjectEmployeeDto projectEmployeeRequest)
    {
        var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(projectId, employeeId);
        if (projectEmployee == null)
        {
            throw new ProjectEmployeeException(projectId, employeeId);
        }

        _mapper.Map(projectEmployeeRequest, projectEmployee);
        await _projectEmployeeRepository.UpdateAsync(projectEmployee);
    }

    public async Task DeleteAsync(Guid projectId, Guid employeeId)
    {
        var projectEmployee = await _projectEmployeeRepository.GetByIdAsync(projectId, employeeId);
        if (projectEmployee == null)
        {
            throw new ProjectEmployeeException(projectId, employeeId);
        }
        await _projectEmployeeRepository.DeleteAsync(projectId, employeeId);
    }
}