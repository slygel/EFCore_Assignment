using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Exceptions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("/api/v1/employees")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var persons = await _employeeService.GetAllAsync();
        return Ok(persons);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        return Ok(employee);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EmployeeDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] EmployeeRequestDto employee)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _employeeService.CreateAsync(employee);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        catch (DepartmentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeRequestDto employee)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _employeeService.UpdateAsync(id, employee);
            return Ok("Update success!");
        }
        catch (EmployeeException e)
        {
            return NotFound(e.Message);
        }
        catch (DepartmentException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _employeeService.DeleteAsync(id);
            return Ok("Delete success!");
        }
        catch (EmployeeException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet("departments")]
    public async Task<IActionResult> GetAllWithDepartment()
    {
        var employees = await _employeeService.GetAllWithDepartmentAsync();
        return Ok(employees);
    }

    [HttpGet("projects")]
    public async Task<IActionResult> GetAllWithProjects()
    {
        var employees = await _employeeService.GetAllWithProjectsAsync();
        return Ok(employees);
    }

    [HttpGet("salaryDate")]
    public async Task<IActionResult> GetEmployeesBySalaryAndDateRawSql(
        [FromQuery] decimal minSalary = 100,
        [FromQuery] DateTime minDate = default)
    {
        if (minDate == default) minDate = new DateTime(2024, 1, 1);
        var employees = await _employeeService.GetEmployeesBySalaryAndDateRawSqlAsync(minSalary, minDate);
        return Ok(employees);
    }
}