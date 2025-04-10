using Application.DTOs.Requests;
using Application.Exceptions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class ProjectEmployeeController : ControllerBase
{
    private readonly IProjectEmployeeService _projectEmployeeService;

    public ProjectEmployeeController(IProjectEmployeeService projectEmployeeService)
    {
        _projectEmployeeService = projectEmployeeService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        var projectEmployees = await _projectEmployeeService.GetAllAsync();
        return Ok(projectEmployees);
    }
    
    [HttpGet("{projectId}/{employeeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid projectId, Guid employeeId)
    {
        try
        {
            var projectEmployee = await _projectEmployeeService.GetByIdsAsync(projectId, employeeId);
            return Ok(projectEmployee);
        }
        catch (ProjectEmployeeException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] ProjectEmployeeRequestDto projectEmployeeRequest)
    {
        try
        {
            var createdProjectEmployee = await _projectEmployeeService.CreateAsync(projectEmployeeRequest);
            return CreatedAtAction(nameof(Get),
                new { projectId = createdProjectEmployee.ProjectId, employeeId = createdProjectEmployee.EmployeeId },
                createdProjectEmployee);
        }
        catch (ProjectEmployeeException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPut("{projectId}/{employeeId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid projectId, Guid employeeId,
        [FromBody] UpdateProjectEmployeeDto projectEmployeeRequest)
    {
        try
        {
            await _projectEmployeeService.UpdateAsync(projectId, employeeId, projectEmployeeRequest);
            return Ok("Update successful");
        }
        catch (ProjectEmployeeException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpDelete("{projectId}/{employeeId}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid projectId, Guid employeeId)
    {
        try
        {
            await _projectEmployeeService.DeleteAsync(projectId, employeeId);
            return Ok("Delete successful");
        }
        catch (ProjectEmployeeException ex)
        {
            return NotFound(ex.Message);
        }
    }
}