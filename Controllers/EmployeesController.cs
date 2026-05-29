using Microsoft.AspNetCore.Mvc;
using EmployeeCrudApi.Models;
using EmployeeCrudApi.DTOs;
using EmployeeCrudApi.Services;

namespace EmployeeCrudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _employeeService.GetAllEmployees();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Department = dto.Department,
            Salary = dto.Salary,
            JoiningDate = dto.JoiningDate,
            IsActive = dto.IsActive
        };

        var createdEmployee = await _employeeService.CreateEmployee(employee);

        return Ok(createdEmployee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto dto)
    {
        var employee = new Employee
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Department = dto.Department,
            Salary = dto.Salary,
            JoiningDate = dto.JoiningDate,
            IsActive = dto.IsActive
        };

        var updatedEmployee = await _employeeService.UpdateEmployee(id, employee);

        if (updatedEmployee == null)
        {
            return NotFound();
        }

        return Ok(updatedEmployee);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var deleted = await _employeeService.DeleteEmployee(id);

        if (!deleted)
        {
            return NotFound();
        }

        return Ok("Employee deleted successfully");
    }
}