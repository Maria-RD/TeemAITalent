using TeemAITalent.Application.Interfaces;
using TeemAITalent.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TeemAITalent.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _repository;

    public EmployeesController(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetAll()
    {
        var employees = await _repository.GetAllAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetById(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<List<Employee>>> Search(string searchTerm)
    {
        var employees = await _repository.SearchAsync(searchTerm);
        return Ok(employees);
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> Create(Employee employee)
    {
        var created = await _repository.CreateAsync(employee);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Employee employee)
    {
        if (id != employee.Id)
            return BadRequest();

        await _repository.UpdateAsync(employee);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}