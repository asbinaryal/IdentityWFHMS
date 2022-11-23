using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WFHMS.Data.Entities;
using WFHMS.Models.ViewModel;
using WFHMS.Repository.Infrastructure;
using WFHMS.Services.Services;

namespace WFHMS.API.Controllers;


[ApiController]

[Route("api/[controller]")]

public class DepartmentController : ControllerBase
{
    private readonly ILogger<DepartmentController> _logger;
    private readonly IDepartmentServices departmentServices;





    public DepartmentController(ILogger<DepartmentController> logger, IDepartmentServices departmentServices)
    {
        this._logger = logger;
        this.departmentServices = departmentServices;


    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dep = await departmentServices.GetAll();
        return Ok(dep);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var existing = await departmentServices.GetAsync(id);
            if (existing == null)
            {
                return BadRequest("Id Doesn't Exists!");
            }
            return Ok(existing);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(DepartmentCreateViewModel department)
    {
        try
        {
            await departmentServices.Add(department);
            return Ok();
        }
        catch (Exception ex)
        {
            //  _logger.LogWarn(ex.Message);
            return BadRequest(ApiConstants.Unable_To_Save);
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(DepartmentListViewModel department)
    {
        try
        {
            await departmentServices.Update(department);
            return Ok();
        }
        catch (Exception ex)
        {
            //  _logger.LogWarn(ex.Message);
            return BadRequest("Some error stops you..please contact your admin");
        }

    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        try
        {
            var del = await departmentServices.GetAsync(id);
            if (del == null)
            {
                return NotFound("Id not Found");
            }
           
            await departmentServices.Delete(del);
            return Ok();
        }
        catch (Exception ex)
        {
            //  _logger.LogWarn(ex.Message);
            return BadRequest("Some error stops you..please contact your admin");
        }
    }
}











