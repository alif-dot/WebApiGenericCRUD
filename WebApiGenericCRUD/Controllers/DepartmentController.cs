using Microsoft.AspNetCore.Mvc;
using WebApiGenericCRUD.Models;
using WebApiGenericCRUD.Repository;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private IRepository<Department> _departmentRepository;
    public DepartmentController(IRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [HttpGet]
    [Route("GetAllDepartments")]
    public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
    {
        return Ok(await _departmentRepository.GetAll());
    }

    [HttpGet]
    [Route("GetDepartmentById/{id}")]
    public async Task<ActionResult<Department>> GetDepartmentById(Int64 id)
    {
        return Ok(await _departmentRepository.GetByIdAsync(id));
    }

    [HttpGet]
    [Route("GetDepartmentByName/{departmentName}")]
    public async Task<ActionResult<Department>> GetDepartmentByName(string departmentName)
    {
        return Ok(await _departmentRepository.FindByConditionAsync(x => x.Name == departmentName));
    }

    [HttpPost]
    [Route("AddDepartment")]
    public async Task<IActionResult> AddDepartment([FromBody] Department department)
    {
        var newDepartment = new Department
        {
            Name = department.Name,
            Description = department.Description,
            Address = department.Address
        };

        _departmentRepository.Add(newDepartment);
        return Ok(await _departmentRepository.SaveChangesAsync());
    }


    [HttpPut]
    [Route("UpdateDepartment")]
    public async Task<IActionResult> UpdateDepartment([FromBody] Department department)
    {
        _departmentRepository.Update(department);
        return Ok(await _departmentRepository.SaveChangesAsync());
    }

    [HttpDelete]
    [Route("DeleteDepartment")]
    public async Task<IActionResult> DeleteDepartment(Int64 id)
    {
        await _departmentRepository.Delete(id);
        return Ok(await _departmentRepository.SaveChangesAsync());
    }
}