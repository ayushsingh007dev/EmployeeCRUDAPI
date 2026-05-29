using EmployeeCrudApi.Data;
using EmployeeCrudApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudApi.Services;

public class EmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee?> UpdateEmployee(int id, Employee updatedEmployee)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return null;
        }

        employee.FullName = updatedEmployee.FullName;
        employee.Email = updatedEmployee.Email;
        employee.Department = updatedEmployee.Department;
        employee.Salary = updatedEmployee.Salary;
        employee.JoiningDate = updatedEmployee.JoiningDate;
        employee.IsActive = updatedEmployee.IsActive;

        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();

        return true;
    }
}