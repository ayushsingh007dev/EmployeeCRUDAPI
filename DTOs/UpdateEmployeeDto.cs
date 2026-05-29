using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudApi.DTOs;

public class UpdateEmployeeDto
{
    [Required]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Department { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public DateTime JoiningDate { get; set; }

    public bool IsActive { get; set; }
}