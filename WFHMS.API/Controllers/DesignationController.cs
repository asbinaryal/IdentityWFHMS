using Microsoft.AspNetCore.Mvc;
using WFHMS.Models.ViewModel;
using WFHMS.Services.Services;

namespace WFHMS.API.Controllers
{

    [ApiController]

    [Route("api/[controller]")]

    public class DesignationController : ControllerBase
    {
        private readonly ILogger<DesignationController> _logger;
        private readonly IDesignationServices designationServices;


        public DesignationController(ILogger<DesignationController> logger, IDesignationServices designationServices)
        {
            _logger = logger;
            this.designationServices = designationServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var deg = await designationServices.GetAll();
            return Ok(deg);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var existing = await designationServices.GetAsync(id);
            if (existing == null)
            {
                return BadRequest("Id Doesn't Exists!");
            }
            return Ok(existing);
        }
        [HttpPost]
        public async Task<IActionResult> Add(DesignationCreateViewModel designation)
        {
            try
            {
                await designationServices.Add(designation);
                return Ok();
            }
            catch (Exception ex)
            {
                //  _logger.LogWarn(ex.Message);
                return BadRequest(ApiConstants.Unable_To_Save);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(DesignationCreateViewModel designation)
        {
            try
            {
                await designationServices.Update(designation);
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
                var delt = await designationServices.GetAsync(id);
                if (delt == null)
                {
                    return NotFound();
                }
                else
                {
                    await designationServices.Delete(delt);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                //  _logger.LogWarn(ex.Message);
                return BadRequest("Some error stops you..please contact your admin");
            }
        }
    }
}