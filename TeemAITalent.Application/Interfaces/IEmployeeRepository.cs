using TeemAITalent.Domain.Entities;

namespace TeemAITalent.Application.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task<List<Employee>> SearchAsync(string searchTerm);
    Task<Employee> CreateAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}