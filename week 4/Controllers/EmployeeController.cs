using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee
        {
            Id = 1,
            Name = "John Doe",
            Salary = 50000,
            Permanent = true,
            Department = new Department { Id = 1, Name = "HR" },
            Skills = new List<Skill>
            {
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "SQL" }
            },
            DateOfBirth = new DateTime(1990, 1, 1)
        }
    };

    [HttpGet]
    public ActionResult<List<Employee>> GetAll()
    {
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        var emp = employees.Find(e => e.Id == id);
        if (emp == null) return NotFound();
        return Ok(emp);
    }

    [HttpPost]
    public ActionResult<Employee> Post([FromBody] Employee employee)
    {
        employee.Id = employees.Count + 1;
        employees.Add(employee);
        return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Employee updated)
    {
        var emp = employees.Find(e => e.Id == id);
        if (emp == null) return BadRequest("Invalid employee id");
        emp.Name = updated.Name;
        emp.Salary = updated.Salary;
        emp.Permanent = updated.Permanent;
        emp.Department = updated.Department;
        emp.Skills = updated.Skills;
        emp.DateOfBirth = updated.DateOfBirth;
        return Ok(emp);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var emp = employees.Find(e => e.Id == id);
        if (emp == null) return BadRequest("Invalid employee id");
        employees.Remove(emp);
        return NoContent();
    }
}
