using Microsoft.AspNetCore.Mvc;
using JobPortalProject.Model;
using JobPortalProject.Repository;
using JobPortalProject.Interface;

namespace JobPortalProject.Controllers
{
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IService _Service;
        public DepartmentController(IService Service)
        {
            _Service = Service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [Route("v1/departments/create")]
        public async Task<IActionResult> Postdepartment([FromBody] CreateDepartmentInput input)
        {
            DepartmentSaveModel dr = _Service.CreateDepartment(input);
            return Ok(await Task.FromResult(dr));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [Route("v1/departments/update")]
        public async Task<IActionResult> PutDepartment([FromBody] PutDepartmentInput input, [FromQuery] int id)
        {
            int dr = _Service.PutDepartment(input, id);
            return Ok();
        }
        [HttpGet]
        [Route("v1/departments/{id:int}")]
        public async Task<IActionResult> Getdepartment(int id)
        {
            List<DepartmentModel> dr = _Service.GetDepartment(id);
            return Ok(await Task.FromResult(dr));
        }
    }
}
