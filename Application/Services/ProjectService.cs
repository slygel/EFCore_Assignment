using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProjectDto>> GetAllAsync()
    {
        var projects = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<ProjectDto> GetByIdAsync(Guid id)
    {
        var project = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> CreateAsync(ProjectRequestDto projectRequestDto)
    {
        var project = _mapper.Map<Projects>(projectRequestDto);
        project.Id = Guid.NewGuid();
        await _repository.AddAsync(project);
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task UpdateAsync(Guid id, ProjectRequestDto projectRequestDto)
    {
        var project = await _repository.GetByIdAsync(id);
        if (project == null)
        {
            throw new ProjectException(id);
        }
        _mapper.Map(projectRequestDto, project);
        await _repository.UpdateAsync(project);
    }

    public async Task DeleteAsync(Guid id)
    {
        var project = await _repository.GetByIdAsync(id);
        if (project == null)
        {
            throw new ProjectException(id);
        }
        await _repository.DeleteAsync(id);
    }
}