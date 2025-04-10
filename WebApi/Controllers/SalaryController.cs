using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Exceptions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("/api/v1/salaries")]
[ApiController]
public class SalaryController : ControllerBase
{
    private readonly ISalaryService _salaryService;

    public SalaryController(ISalaryService salaryService)
    {
        _salaryService = salaryService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var salaries = await _salaryService.GetAllAsync();
        return Ok(salaries);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id)
    {
        var salary = await _salaryService.GetByIdAsync(id);
        if (salary == null)
        {
            return NotFound();
        }
        return Ok(salary);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SalaryDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] SalaryRequestDto salaryRequestDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _salaryService.CreateAsync(salaryRequestDto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        catch (EmployeeException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] SalaryRequestDto salaryRequestDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _salaryService.UpdateAsync(id, salaryRequestDto);
            return Ok("Update success!");
        }
        catch (EmployeeException e)
        {
            return NotFound(e.Message);
        }
        catch (SalaryException e)
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
            await _salaryService.DeleteAsync(id);
            return Ok("Delete success!");
        }
        catch (SalaryException e)
        {
            return NotFound(e.Message);
        }
    }
}