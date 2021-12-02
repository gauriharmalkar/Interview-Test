using Microsoft.AspNetCore.Mvc;
using JobPortalProject.Model;
using JobPortalProject.Repository;
using JobPortalProject.Interface;

namespace JobPortalProject.Controllers
{
    public class LocationController : Controller
    {

        private readonly IService _Service;
        public LocationController(IService Service)
        {
            _Service = Service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [Route("v1/Location/create")]
        public async Task<IActionResult> PostLocation([FromBody] CreateLocationInput input)
        {
            LocationSaveModel dr = _Service.CreateLocation(input);
            return Ok(await Task.FromResult(dr));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [Route("v1/Location/update")]
        public async Task<IActionResult> PutLocation([FromBody] PutLocationInput input, [FromQuery] int id)
        {
            int dr = _Service.PutLocation(input, id);
            return Ok();
        }
        [HttpGet]
        [Route("v1/Location/{id:int}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            List<locationModel> dr = _Service.GetLocation(id);
            return Ok(await Task.FromResult(dr));
        }
    }
}
